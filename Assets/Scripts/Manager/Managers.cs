using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static Define;

public class Managers : MonoBehaviour
{
    public static Managers Instance { get; private set; }

    //private static DataManager dataManager = new();//
    private static UIManager uiManager = new();
    private static ResourceManager resourceManager = new();
    private static GameManager gameManager = new();
    private static SoundManager soundManager = new SoundManager();

    //public static DataManager Data { get { Init(); return dataManager; } }
    public static UIManager UI { get { Init(); return uiManager; } }
    public static ResourceManager Resource { get { Init(); return resourceManager; } }
    public static GameManager Game { get { Init(); return gameManager; } }
    public static SoundManager Sound { get { Init(); return soundManager; } }

    void Start()
    {
        Init();
    }

    private static void Init()
    {
        if (Instance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
                go = new GameObject { name = "@Managers" };

            Instance = Utils.GetOrAddComponent<Managers>(go);
            DontDestroyOnLoad(go);

            soundManager.Init();

            Application.targetFrameRate = 60;
        }
    }
}
