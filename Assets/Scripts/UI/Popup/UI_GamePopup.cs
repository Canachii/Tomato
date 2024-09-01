using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_GamePopup : UI_Popup
{
    private Trap[] _traps;
    [SerializeField]
    private Rigidbody2D[] _rbs;
    [SerializeField]
    private GameObject[] deactivatedObjects;
    [SerializeField]
    private Slider slider;
    [SerializeField]
    private float clearTime;
    private bool isRunning;

    enum Buttons
    {
        InstallationCompleteButton,
    }


    public void Update()
    {
        if (isRunning)
        {
            slider.value -= Time.deltaTime;
            if (slider.value <= 0)
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
        
        _traps = GetComponentsInChildren<Trap>();

        slider.maxValue = clearTime;
        slider.value = slider.maxValue;

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

        foreach (Trap trap in _traps)
        {
            trap.isDrag = false;
        }

        isRunning = true;   

        Managers.Sound.Play(Define.Sound.Effect, "switch_004");
    }

    public void GameEnd()
    {
        isRunning = false;
    }

}
