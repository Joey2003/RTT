using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public Transform shop;
    public CanvasGroup background;
    public Shop shopGroup;
    public Vector3 screenCenterA;
    public Vector3 screenCenterB;
    public CameraHandler camHandle;
    private float offset = 1000;
    public bool invoke;

    private void OnEnable()
    {
        invoke = true;
        screenCenterA = new Vector2(0, 5);
        screenCenterB = new Vector2(0, -5);
        shop.localPosition = new Vector2(0, Screen.height + offset);
        shop.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void CloseShop()
    {
        background.LeanAlpha(0, 0.5f);
        if (CenterofScreen())
        {
            shop.LeanMoveLocalY(-Screen.height - offset, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        }else
        {
            OnComplete();
        }
    }

    public void Transition()
    {
        shop.LeanMoveLocalY(Screen.height + offset, 0.5f).setEaseInExpo();
    }

    void OnComplete()
    {
        invoke = false;
        gameObject.SetActive(false);
    }

    public void SetActive()
    {
        if (gameObject.activeSelf)
        {
            shop.LeanMoveLocalY(0, 0.5f).setEaseInExpo();
        } else
        {
            gameObject.SetActive(true);
        }
    }

    bool CenterofScreen()
    {
        if (shop.localPosition.y >= screenCenterB.y && shop.localPosition.y <= screenCenterA.y)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
