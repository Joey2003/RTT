using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    public Items subShop;
    public Items subShop2;
    public Items subShop3;
    public Items subShop4;
    public Shop shopGroup;
    public CameraHandler camHandle;
    public bool invoke;

    public void CloseShops()
    {
        invoke = false;
        subShop.CloseShop();
        subShop2.CloseShop();
        subShop3.CloseShop();
        subShop4.CloseShop();
        shopGroup.CloseShop();

    }
}
