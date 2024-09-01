using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GameOverPopup : UI_Popup
{
    enum Buttons
    {
        RetryButton,
        HomeButton,
    }
    public override bool Init()
    {
        if (base.Init() == false)
            return false;
        //BindText(typeof(Texts));
        BindButton(typeof(Buttons));

        GetButton((int)Buttons.RetryButton).gameObject.BindEvent(OnClickRetryButtonButton);
        GetButton((int)Buttons.HomeButton).gameObject.BindEvent(OnClickHomeButtonButton);


        return true;
    }

    void OnClickRetryButtonButton()
    {
        Debug.Log("OnClickRetryButtonButton");

        Managers.UI.CloseAllPopupUI();

        Managers.UI.ShowPopupUI<UI_GamePopup>();

    }    
    
    void OnClickHomeButtonButton()
    {
        Debug.Log("OnClickHomeButtonButton");

        Managers.UI.CloseAllPopupUI();

        Managers.UI.ShowPopupUI<UI_TitlePopup>();

    }


}
