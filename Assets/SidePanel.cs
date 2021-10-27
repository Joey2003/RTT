using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidePanel : MonoBehaviour
{
    public CanvasGroup background;
    public Transform panel, m_in , m_out;
    public Vector3 screenCenterA, screenCenterB;
    public GameObject exit;
    public Transform content;
    public GameObject shopButton;
    public CameraHandler camHandle;
    private float inPos;
    private float outPos;
    public bool backgroundActive;
    public bool invoke;


    public void PopOut()
    {
        inPos = m_in.localPosition.x;//1535.33f;
        outPos = m_out.localPosition.x;//inPos - offset;

        if (!CenterofScreen())
        {
            invoke = true;
            if (background != null)
            {
                background.gameObject.SetActive(true);
            }
            shopButton.gameObject.SetActive(false);
            exit.SetActive(true);
            content.gameObject.SetActive(true);

            if (background != null)
            {
                background.alpha = 0;
                background.LeanAlpha(1, 0.5f);
            }
            screenCenterA = new Vector2(outPos + 50, outPos + 50);
            screenCenterB = new Vector2(outPos - 50, outPos - 50);
        //    panel.localPosition = new Vector2(inPos, 0);
            panel.LeanMoveLocalX(outPos, 0.5f).setEaseOutExpo();
        }
    }

    public void CloseShop()
    {
        if (CenterofScreen())
        {
            if (background != null)
            {
                background.LeanAlpha(0, 0.5f).setOnComplete(OnComplete);
            }
            panel.LeanMoveLocalX(inPos, 0.5f).setEaseInExpo();
            shopButton.gameObject.SetActive(true);
        }
    }

    void OnComplete()
    {
        invoke = false;
        if (background != null)
        {
            background.gameObject.SetActive(false);
        }
        exit.gameObject.SetActive(false);
        content.LeanMoveLocalY(0f, 0);
        content.gameObject.SetActive(false);
    }

    bool CenterofScreen()
    {
        if (panel.localPosition.x >= screenCenterB.x && panel.localPosition.x <= screenCenterA.x)
        {
            return true;
        }
        else
        {
            return false;
        }

    }
}
