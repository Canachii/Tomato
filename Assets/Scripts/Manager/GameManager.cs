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
        Managers.UI.ShowPopupUI<UI_GameOverPopup>();
    }

    public void GameClear()
    {
        Debug.Log("GameClear");
        GameEnd?.Invoke();
        Managers.UI.ShowPopupUI<UI_GameClearPopup>();
    }
}
