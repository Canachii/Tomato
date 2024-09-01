using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;
using UnityEngine.Android;

public class UI_GameRulePopup : UI_Popup
{
    enum Buttons
    {
        BackGroundButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        //BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.BackGroundButton).gameObject.BindEvent(OnClickBackGroundButton);


        return true;
    }

    void OnClickBackGroundButton()
    {
        Debug.Log("OnClickBackGroundButton");

        Managers.UI.ClosePopupUI(this);

        Managers.UI.ShowPopupUI<UI_GamePopup>();

    }
}
