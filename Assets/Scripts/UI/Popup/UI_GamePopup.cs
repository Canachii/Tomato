using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_GamePopup : UI_Popup
{
    [SerializeField]
    private Rigidbody2D[] _rbs;
    [SerializeField]
    private GameObject[] deactivatedObjects;
    [SerializeField]
    private float clearTime;
    private float runningTime = 0f;
    private bool isRunning;

    enum Buttons
    {
        InstallationCompleteButton,
    }

    public void Update()
    {
        if (isRunning)
        {
            runningTime += Time.deltaTime;
            if (runningTime >= clearTime)
            {
                Managers.Game.GameClear();
                isRunning = false;
            }
        }
         
    }


    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        isRunning = false;

        Managers.Game.GameEnd += GameEnd;

        foreach (Rigidbody2D rb in _rbs)
        {
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        foreach (GameObject go in deactivatedObjects)
        {
            go.gameObject.SetActive(true);
        }
        

        BindButton(typeof(Buttons));

        GetButton((int)Buttons.InstallationCompleteButton).gameObject.BindEvent(OnClickInstallationCompleteButton);


        return true;
    }

    void OnClickInstallationCompleteButton()
    {
        Debug.Log("OnClickInstallationCompleteButton");

        foreach (Rigidbody2D rb in _rbs)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        foreach (GameObject go in deactivatedObjects)
        {
            go.gameObject.SetActive(false);
        }

        isRunning = true;   

    }

    public void GameEnd()
    {
        isRunning = false;
    }

}
