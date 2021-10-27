using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teammatetab : MonoBehaviour
{
    public Transform shop;
    public CanvasGroup background;
    public Vector3 screenCenterA, screenCenterB;
    public Items subshop;

    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        screenCenterA = new Vector2(0, 5);
        screenCenterB = new Vector2(0, -5);
        shop.localPosition = new Vector2(Screen.width + 13, 0);
        shop.LeanMoveLocalX(0, 0.5f).setEaseOutExpo().delay = 0.5f;
    }

    public void CloseShop()
    {
        background.LeanAlpha(0, 0.5f);
        if (CenterofScreen())
        {
            shop.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        }
        else
        {
            OnComplete();
        }
    }

    public void Transition()
    {
        shop.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo();
    }
    public void ReverseTransition()
    {
        shop.LeanMoveLocalY(0, 0.5f).setEaseInExpo();
    }

    void OnComplete()
    {
        gameObject.SetActive(false);
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
