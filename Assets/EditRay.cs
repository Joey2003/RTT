using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditRay : MonoBehaviour
{
    public Vector3 touchWorldPos;
    public float height;
    public float holdTime_edit;
    public float threshold_edit;
    public Vector3 targetPos;
    public Ray ray;
    public RaycastHit hit;
    public GameObject[] hits;
    public bool hitObject;
    public GameObject sidePanel, shopButton;
    Touch touch;
    public bool editMode;
    float holdTime;
    float startTime;
    Vector2 startPos;
    Vector2 deltaPos;
    public Edit edit;
    public Plane plane;
    public Translate trans;
    public Purchase purchase;

    private void Start()
    {
        plane = new Plane(
        new Vector3(-40, height, 55),
        new Vector3(10, height, 55),
        new Vector3(-25, height, -10)); //plane(a, b, c)
    }

    void Update()
    {
        touch = Input.GetTouch(0);
       
        deltaPos = Input.GetTouch(0).deltaPosition;

        if (touch.phase == TouchPhase.Began)
        {
            startTime = Time.time;
            startPos = touch.position;
        }



        float distance;

        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (plane.Raycast(ray, out distance))
        {
            touchWorldPos = ray.GetPoint(distance);

            
            targetPos = touchWorldPos;
            Debug.DrawRay(ray.origin, ray.direction * 10);
        }

        //print(touch.deltaPosition);
        if (TouchingEditable())
        {
            trans._object = hit.collider.gameObject;
        }

        if ((touch.position == startPos  //touch.deltaPosition == new Vector2(0, 0) does not work
            && touch.phase == TouchPhase.Stationary
            && Time.time <= startTime + holdTime_edit + .25) &&
            Time.time >= startTime + holdTime_edit &&
        TouchingEditable() && !editMode)
        {
            editMode = true;
            sidePanel.SetActive(false);
            edit.editButtons();
        }

        if (editMode)
        {
            shopButton.SetActive(false);
        }
    } 

    public bool TouchingEditable()    //returns true if touching an editable object
    {
        if (Physics.Raycast(ray, out hit) && (hit.collider != null) && (hit.collider.gameObject.CompareTag("Editable") || hit.collider.gameObject.CompareTag("Special_Editable")))
        {
            return true; //make it so its until the user releases the screen

        } else if (touch.phase == TouchPhase.Ended)
        {
            return false;
        } else
        {
            return false;
        }
    }

    public bool Touching(GameObject object_)
    {
        if (Physics.Raycast(ray, out hit) && (hit.collider != null) && (hit.collider == object_.GetComponent<BoxCollider>()))
        {
            return true; //make it so its until the user releases the screen
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            return false;
        }
        else
        {
            return false;
        }
    }

    public void EnterEditMode()
    {
        editMode = true;
        purchase.resetAmount();
        sidePanel.SetActive(false);
        edit.editButtons();
    }


    
}
 