using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_TitlePopup : UI_Popup
{
    enum Buttons
    {
        GameStartButton,
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.GameStartButton).gameObject.BindEvent(OnClickPlayButton);


        return true;
    }


    void OnClickPlayButton()
    {
        Debug.Log("OnClickPlayButton");

        Managers.UI.ClosePopupUI(this);

        Managers.UI.ShowPopupUI<UI_GamePopup>();
        
        Managers.Sound.Play(Define.Sound.Effect, "switch_004");
    }
}
