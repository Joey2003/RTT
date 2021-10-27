using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class History : MonoBehaviour
{
    public Vector3 lastPos;
    public Quaternion lastRot;
    EditRay ray;
    public bool restricted, invoker;

    string objectTag;
    // Start is called before the first frame update
    void Start()
    {
        objectTag = this.gameObject.tag;
        //invoker = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.tag == "Special_Editable")
        {
            CheckFloating();
        }

        ray = Camera.main.GetComponent<EditRay>();
        if(!ray.editMode)
        {
            lastPos = this.gameObject.transform.position;  //gets position of object up until its in edit mode
            lastRot = this.gameObject.transform.rotation;

            //print(lastPos);
        }

        foreach(GameObject gameObject in GameObject.FindGameObjectsWithTag(objectTag))
        {
            if(gameObject != this.gameObject && (gameObject.transform.position.x == this.transform.position.x && gameObject.transform.position.z == this.transform.position.z))     // if this gameobject is on top of anything it shouldnt be, put the error box
            {
                //print("**");
                restricted = true;
                break;
            } else if (this.gameObject.tag == "Special_Editable" && invoker)
            {
                restricted = true;
                break;
            }
            else if (this.gameObject.tag == "Special_Editable" && !invoker)
            {
                restricted = false;
            } else
            {
                restricted = false;
            }
        }


    }
     
    private void CheckFloating()
    {
        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Editable"))
        {
            if (gameObject.transform.position.x == this.transform.position.x && gameObject.transform.position.z == this.transform.position.z)
            {
                //check if 'gameObject' is a counter
                //dont want to put a 3d printer on a resource rack or programming table lol.
                if (gameObject.name.StartsWith("Counter") || gameObject.name.StartsWith("counter"))
                {
                    invoker = false;
                    print("not floating");
                    break;
                } else
                {
                    invoker = true;
                }
            } else
            {
                invoker = true;
                print("Floating");
            }
        }
    }
}
