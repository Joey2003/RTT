using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Correct : MonoBehaviour
{
    bool needsCorrection;
     public void correct()
    {
        foreach (GameObject gameObject in FindGameObjectsWithLayer(8)) //Layer: Editable
        {
            if (gameObject.GetComponent<History>().restricted)
            {
                needsCorrection = true;
                break;
            } else
            {
                needsCorrection = false;
            }
        }

        foreach (GameObject obj in FindGameObjectsWithLayer(8)) //Layer: Editable
        {
            if (needsCorrection)
            {
                obj.transform.position = obj.GetComponent<History>().lastPos;
                obj.transform.rotation = obj.GetComponent<History>().lastRot;
            }
        }
    }

    private GameObject[] FindGameObjectsWithLayer(int layer)
    {
        GameObject[] goArray = FindObjectsOfType<GameObject>();
        List<GameObject> goList = new List<GameObject>();

        for (int i = 0; i < goArray.Length; i++) 
        {

            if (goArray[i].layer == layer) 
            {
                goList.Add(goArray[i]);
            }
        }

        if (goList.Count == 0) 
        {
            return null;
        }

        return goList.ToArray();
    }

}
