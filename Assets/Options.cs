using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Options : MonoBehaviour
{
    public Transform panel;
    public CanvasGroup background;
    public Vector3 screenCenterA, screenCenterB;
    private float offset = 700;
    public CameraHandler camHandle;
    public bool invoke;


    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1, 0.5f);
        screenCenterA = new Vector2(0, 5);
        screenCenterB = new Vector2(0, -5);
        panel.localPosition = new Vector2(0, -Screen.height - offset);
        panel.LeanMoveLocalY(0, 0.5f).setEaseOutExpo().delay = 0.5f;
        invoke = true;
    }

    public void Close()
    {
        background.LeanAlpha(0, 0.5f);
        if (CenterofScreen())
        {
            panel.LeanMoveLocalY(-Screen.height, 0.5f).setEaseInExpo().setOnComplete(OnComplete);
        }
        else
        {
            OnComplete();
        }
    }

    void OnComplete()
    {
        invoke = false;
        gameObject.SetActive(false);
    }

    bool CenterofScreen()
    {
        if (panel.localPosition.y >= screenCenterB.y && panel.localPosition.y <= screenCenterA.y)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
