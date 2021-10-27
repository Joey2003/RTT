using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Edit : MonoBehaviour
{
    public Transform inventory_in, inventory_out, inventory;
    public Transform inventoryButton_in, inventoryButton_out, inventoryButton;
    public Transform confirmButton_in, confirmButton_out, confirmButton;
    public GameObject editBar, shopButton, teammateTab;
    private float inv_in;
    private float inv_Out;
    private float invBut_in;
    private float invBut_Out;
    private float conf_in;
    private float conf_out;
    public EditRay ray;
    public Purchase purchase;
    private void Update()
    {
        inv_in = inventory_in.localPosition.x;//1535.33f;
        inv_Out = inventory_out.localPosition.x;//inPos - offset;
        invBut_in = inventoryButton_in.localPosition.y;//1535.33f;
        invBut_Out = inventoryButton_out.localPosition.y;//inPos - offset;
        conf_in = confirmButton_in.localPosition.y;
        conf_out = confirmButton_out.localPosition.y;

    }

    public void editButtons()
    {
        popOut_Y(confirmButton, conf_out);
        popOut_Y(inventoryButton, invBut_Out);
        editBar.SetActive(true);
        shopButton.SetActive(false);
        teammateTab.SetActive(false);
    }

    public void closeEditMode()
    {
        ray.editMode = false;
        editButtonsAway();
        purchase.resetAmount();
    }

    public void editButtonsAway()
    {
        popOut_Y(confirmButton, conf_in);
        popOut_Y(inventoryButton, invBut_in);
        editBar.SetActive(false);
        shopButton.SetActive(true);
        teammateTab.SetActive(true);
        inventoryIn(false);
    }

    public void inventoryIn(bool _in)
    {
        if (_in == true)
        {
            popOut_X(inventory, inv_Out);
        } else
        {
            popOut_X(inventory, inv_in);
        }
    }


    private void popOut_X(Transform ui, float pos)
    {
        ui.LeanMoveLocalX(pos, 0.5f).setEaseOutExpo();

    }

    private void popOut_Y(Transform ui, float pos)
    {
        ui.LeanMoveLocalY(pos, 0.5f).setEaseOutExpo();
        //print(ui.name +" "+ ui.localPosition.y +"|target:"+ pos);

    }


}
