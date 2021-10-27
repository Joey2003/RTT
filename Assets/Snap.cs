using UnityEngine;
using UnityEngine.UI;

public class Snap : MonoBehaviour
{
    [SerializeField] private Vector3 gridSize;
    [SerializeField] private Vector3 gridOffset;
    EditRay ray;
    Touch touch;
    public bool startTouch; //if started touch on editable object
    float startTime;
    public bool invoke;
    private bool editable;
    public float holdTime_edit;
    public string objectTag;


    void Update()
    {

        ray = Camera.main.GetComponent<EditRay>();

        if (touch.phase == TouchPhase.Began)
        {
            startTime = Time.time;
        }

        if (ray.editMode)
        {
            for (int a = 0; a <= GameObject.FindGameObjectsWithTag(objectTag).Length - 1; a++)
            {
                if (GameObject.FindGameObjectsWithTag(objectTag)[a] != this.gameObject && GameObject.FindGameObjectsWithTag(objectTag)[a].GetComponent<Snap>().startTouch == false)
                {
                    editable = true;
                } else if (GameObject.FindGameObjectsWithTag(objectTag)[a] != this.gameObject && GameObject.FindGameObjectsWithTag(objectTag)[a].GetComponent<Snap>().startTouch == true)
                {
                    editable = false;
                }
                else if (GameObject.FindGameObjectsWithTag(objectTag)[a] == this.gameObject)
                {
                    continue;
                }
            }
        }

            touch = Input.GetTouch(0);

        if (touch.phase == TouchPhase.Stationary && Time.time <= startTime + holdTime_edit
            && ray.Touching(this.gameObject))
        {
            if (editable)
            {
                startTouch = true;
            } else
            {
                startTouch = false;

            }
        }
        else if (Time.time <= startTime + holdTime_edit
            && !ray.Touching(this.gameObject))
        {
            startTouch = false;
        }
        else if (touch.phase == TouchPhase.Ended)
        {
            startTouch = false;
        }


        if (ray.editMode)
        {
            
            if (startTouch == true)
            {
                invoke = true;
                if (this.gameObject.CompareTag("Editable"))
                {
                SnapToGrid(64.51f);
                } else if (this.gameObject.CompareTag("Special_Editable"))
                {
                    SnapToGrid(65.15f);
                }

            } else
            {
                invoke = false;
                print(this.gameObject.name + "cam invoke = false");
            }
        }
    }



    private void SnapToGrid(float height)
    {
        Vector3 touchPos = ray.touchWorldPos;
        touch = Input.GetTouch(0);
        var position = new Vector3(
            Mathf.Round(touchPos.x / gridSize.x) * gridSize.x + gridOffset.x,

			height,

			Mathf.Round(touchPos.z / gridSize.z) * gridSize.z + gridOffset.z);
        this.transform.position = position;

    }
}
