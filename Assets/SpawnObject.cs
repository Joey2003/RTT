using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject obj;
    private float endTime;
    public float currentTime;
    private EditRay ray;
    private bool startTimer;
    // Start is called before the first frame update
    void Start()
    {
        //timer starts on instantiation
        //spawn() at the end of timer
        ray = Camera.main.GetComponent<EditRay>();
        endTime = obj.GetComponent<ObjectInfo>().BUILD_TIME;
        currentTime = endTime;
        startTimer = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (!ray.editMode)
        {
            startTimer = true;
        }

        if (startTimer)
        {
            currentTime = endTime - Time.time;
            if (currentTime <= 0.0f)
            {
                currentTime = 0.0f;
                spawn();
            }
        }
    }

    public void spawn()
    {
        if (obj != null)
        {
            Instantiate(obj, this.transform.position, new Quaternion(0, 0, 0, 1));
        }
        Destroy(this.gameObject);
    }

    public void resetTime()
    {
        if (currentTime == endTime)
        {
            endTime += Time.time;
        }
    }
}
