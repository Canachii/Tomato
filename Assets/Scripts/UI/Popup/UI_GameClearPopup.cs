using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameClearPopup : UI_Popup
{
    enum Buttons
    {
        HomeButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.HomeButton).gameObject.BindEvent(OnClickHomeButtonButton);


        return true;
    }

    void OnClickHomeButtonButton()
    {
        Debug.Log("OnClickHomeButtonButton");

        Managers.UI.CloseAllPopupUI();

        Managers.UI.ShowPopupUI<UI_TitlePopup>();
        
        Managers.Sound.Play(Define.Sound.Effect, "switch_004");
    }
}
