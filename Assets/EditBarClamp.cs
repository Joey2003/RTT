using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditBarClamp : MonoBehaviour
{
    public Image editBar;
    public float offset;
    void Update()
    {
        
        Vector3 objectPos = Camera.main.ScreenToWorldPoint(editBar.transform.position);//WorldToScreenPoint(this.transform.position);
        var barPos = new Vector3(objectPos.x, objectPos.y + offset, objectPos.z);

        editBar.transform.position = barPos;
    }
}
