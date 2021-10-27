using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Purchase : MonoBehaviour
{
    private int roboCoin;
    public GameObject crate, timer_;
    public Transform canvas;
    private GameObject obj, timer, buyable;
    public Translate trans;
    public int amount;
    public GameObject[] buyables;


    private void Start()
    {
        roboCoin = this.gameObject.GetComponent<Currency>().roboCoin;
        amount = 0;
    }
    private void Update()
    {
        this.gameObject.GetComponent<Currency>().roboCoin = roboCoin;
    }
    public void purchase(string item)
    {
        int price = 0;

        foreach(GameObject buy in buyables)
        {
            if (buy.name.Contains(item))
            {
                price = buy.GetComponent<ObjectInfo>().PRICE;
                buyable = buy;
                break;
            }
        }


        if (roboCoin >= price)
        {
            amount += price;
            obj = Instantiate(crate, new Vector3(-38.2800026f, 64.5100021f, 51.4800034f), new Quaternion(0, 0, 0, 1));

            timer = Instantiate(timer_, canvas);

            timer.GetComponent<Translate>()._object = obj;

            trans._object = obj;
            obj.GetComponent<SpawnObject>().obj = buyable;
            //subtractCoin(price);
        }
    }

    public void purchaseAgain(int price)
    {
        subtractCoin();

        if (roboCoin >= price)
        {
            amount += price;
            obj = Instantiate(crate, new Vector3(-38.2800026f, 64.5100021f, 51.4800034f), new Quaternion(0, 0, 0, 1));

            timer = Instantiate(timer_, canvas);

            timer.GetComponent<Translate>()._object = obj;

            trans._object = obj;
            //subtractCoin(price);
        }
    }
    public void resetTimer()
    {
        if (GameObject.FindGameObjectWithTag("Crate") != null)
        {
            foreach (GameObject crate in GameObject.FindGameObjectsWithTag("Crate"))
            {
                crate.GetComponent<SpawnObject>().resetTime();
            }
        }
    }
    public void resetAmount()
    {
        amount = 0;
    }
    public void subtractCoin()
    {
        if (roboCoin >= amount)
        {
            roboCoin -= amount;
        } else
        {
            return;
        }
    }
}
