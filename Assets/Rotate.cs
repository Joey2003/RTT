using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Translate trans;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void rotateRight()
    {
        trans._object.transform.Rotate(0, 90, 0, Space.World);
    }

    public void rotateLeft()
    {
        trans._object.transform.Rotate(0, -90, 0, Space.World);
    }
}
