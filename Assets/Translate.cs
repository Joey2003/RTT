using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Translate : MonoBehaviour
{
    /*public bool moveButton;
    public bool rotateLeftButton;
    public bool rotateRightButton;*/
    public Transform origin;
    public GameObject _object;
    public float gap = 5;

    private void Start()
    {
        Move();
    }
    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (_object != null)
        {
            origin.position = new Vector3(
                Camera.main.WorldToScreenPoint(_object.transform.position).x,
                Camera.main.WorldToScreenPoint(_object.transform.position).y + gap,
                Camera.main.WorldToScreenPoint(_object.transform.position).z);//Input.mousePosition;
        }
    }
}



