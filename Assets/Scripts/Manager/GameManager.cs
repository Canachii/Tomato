using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager
{
    public event Action GameEnd;

    public void GameOver()
    {
        Debug.Log("GameOver");
        GameEnd?.Invoke();
        Managers.UI.CloseAllPopupUI();
        Managers.UI.ShowPopupUI<UI_GameOverPopup>();
        Managers.Sound.Play(Define.Sound.Effect, "question_001");
    }

    public void GameClear()
    {
        Debug.Log("GameClear");
        GameEnd?.Invoke();
        Managers.UI.CloseAllPopupUI();
        Managers.UI.ShowPopupUI<UI_GameClearPopup>();
        Managers.Sound.Play(Define.Sound.Effect, "confirmation_002");
    }
}
