using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewParent : MonoBehaviour
{
    public GameObject button, prefab;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaceObject()
    {

        Instantiate(prefab, this.transform);
        button.SetActive(false);
    }
    public void DropObject()
    {
        this.transform.DetachChildren();
    }
}
