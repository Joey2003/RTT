using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Currency : MonoBehaviour
{
    public int roboCoin, roboCash;
    public GameObject coins, cash;

    void Start()
    {

    }
    void Update()
    {
        coins.GetComponent<Text>().text = roboCoin.ToString();
        if (roboCoin < 0)
        {
            roboCoin = 0;
        }

        cash.GetComponent<Text>().text = roboCash.ToString();
        if (roboCash < 0)
        {
            roboCash = 0;
        }
    }
}
