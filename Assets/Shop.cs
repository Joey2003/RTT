using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public Transform shop;
    public CanvasGroup background;
    public Vector3 screenCenterA, screenCenterB;
    public Items subshop;
    public CameraHandler camHandle;
    private float offset = 700;
    public bool invoke;

    private void OnEnable()
    {
        invoke = true;
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        screenCenterA = new Vector2(0, 5);
        screenCenterB = new Vector2(0, -5);
        shop.localPosition = new Vector2(0, -Screen.height - offset);
        shop.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void CloseShop()
    {
        background.LeanAlpha(0, 0.5f);
        if (CenterofScreen())
        {
            shop.LeanMoveLocalY(-Screen.height - offset, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        } else
        {
            OnComplete();
        }
    }

    public void Transition()
    {
        shop.LeanMoveLocalY(-Screen.height - offset, 0.5f).setEaseInExpo();
    }
    public void ReverseTransition()
    {
        shop.LeanMoveLocalY(0, 0.5f).setEaseInExpo();
    }

    void OnComplete()
    {
        invoke = false;
        gameObject.SetActive(false);
    }

    bool CenterofScreen()
    {
        if (shop.localPosition.y >= screenCenterB.y && shop.localPosition.y <= screenCenterA.y)
        {
            return true;
        } else
        {
            return false;
        }

    }
}
