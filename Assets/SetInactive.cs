using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetInactive : MonoBehaviour
{
    bool active_1, active_2;
    public GameObject errorBox;
    public GameObject[] boxes = new GameObject[24];
    public bool active;
    // Start is called before the first frame update
    void Start()
    {
        float y = this.transform.position.z;
        int box = 0;
        for(int a = 1; a <= 6; a++)
        {
            float x;
            x = this.transform.position.x;
            for(int b = 1; b <= 4; b++)
            {
                boxes[box] = Instantiate(errorBox, new Vector3(x, this.transform.position.y, y), this.transform.rotation, this.transform);
                boxes[box].SetActive(active);
                x += 1.32f;
                box++;
            }
            y -= 1.32f;
        }
    }

    // Update is called once per frame
    void Update()
    {





        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Editable"))
        {
            if (gameObject.GetComponent<History>().restricted)
            {
                setErrorBox(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));

                break;
            }
        }

        foreach (GameObject gameObject in GameObject.FindGameObjectsWithTag("Special_Editable"))
        {
            if (gameObject.GetComponent<History>().restricted)
            {
                setErrorBox(new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z));

                break;
            }
        }

        foreach(GameObject box in boxes)
        {
            foreach (GameObject special in GameObject.FindGameObjectsWithTag("Special_Editable"))
            {
                if (special.transform.position == new Vector3(box.transform.position.x, special.transform.position.y, box.transform.position.z) && special.GetComponent<History>().restricted)
                {
                    active_1 = true;
                    break;
                } 
                else if (special.transform.position != new Vector3(box.transform.position.x, special.transform.position.y, box.transform.position.z))
                {
                    active_1 = false;
                }
                else
                {
                    active_1 = false;
                    print("special actavating error box");
                }
            }

            foreach (GameObject editable in GameObject.FindGameObjectsWithTag("Editable"))
            {
                if (editable.transform.position == new Vector3(box.transform.position.x, editable.transform.position.y, box.transform.position.z) && editable.GetComponent<History>().restricted)
                {
                    active_2 = true;
                    break;
                }
                else if (editable.transform.position != new Vector3(box.transform.position.x, editable.transform.position.y, box.transform.position.z))
                {
                    active_2 = false;
                }
                else
                {
                    active_2 = false;
                }
            }

            box.SetActive(active_1 || active_2);
        }



    }

    private void setErrorBox(Vector3 pos)
    {
        
        foreach(GameObject box in boxes)
        {
            if (pos.x == box.transform.position.x && pos.z == box.transform.position.z)
            {
                box.transform.position = new Vector3(box.transform.position.x, pos.y, box.transform.position.z);
                //box.SetActive(true);
                break;
            } else
            {
                //box.SetActive(false);

            }
        }


        //errorBox.transform.position = pos;
    }
}
