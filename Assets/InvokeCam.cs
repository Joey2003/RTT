using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeCam : MonoBehaviour
{
    public CameraHandler handler;
    Touch touch;
    public GameObject barrier;
    public float barrierX;
    public bool invoke;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        touch = Input.GetTouch(0);
        barrierX = barrier.transform.position.x;
        //print("Touch: " + touch.position.x);
        //print("barrier: " + barrierX);

        if (touch.position.x >= barrierX)
        {
            invoke = true;
        } else
        {
            invoke = false;
        }
    }
}
