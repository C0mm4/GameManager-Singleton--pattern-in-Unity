using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Resources;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    // static object to access other classes
    static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (!instance)
            {
                instance = FindObjectOfType(typeof(GameManager)) as GameManager;
                if (instance == null)
                    Debug.Log("GameManager Instance is NULL");
            }
            return instance;
        }
    }

    // Declare required static objects

    // Before Scene Change Action
    public Action SceneChangeAction;

    // System Variables
    private bool isPause = false;

    public struct SerializedGameData
    {
        // Resolution Lists
        public List<Resolution> resolLists;
        // Current Resolution
        public Resolution resolCurrent;
        // FullScreen
        public bool isFullScreen;
        // Game Master Volume
        public float gameVol;
        // Game Music Volume;
        public float musicVol;
        // Game Effect Volume;
        public float effectVol;
        // In Game Frame Rate
        public int setFrame;
    }

    public static SerializedGameData gameData = new SerializedGameData();

    private void Awake()
    {
        gameData.resolLists = new List<Resolution>();
        instance = this;
        DontDestroyOnLoad(instance);
        bool isFirstRun = PlayerPrefs.GetInt("isFirstRun", 1) == 1;
        if(isFirstRun)
        {
            // is First Run working
        }
        else
        {
            // else
        }

        // Load PlayerPrefs Datas
        LoadData();

        // Set Screen Resolution and FrameRate
        Screen.SetResolution(gameData.resolCurrent.width, gameData.resolCurrent.height, gameData.isFullScreen);
        Application.targetFrameRate = gameData.setFrame;

        SaveData();

        Init();
    }

    void LoadData()
    {
        // Load Resolution Data
        gameData.resolCurrent.width = PlayerPrefs.GetInt("resolW", Screen.currentResolution.width);
        gameData.resolCurrent.height = PlayerPrefs.GetInt("resolW", Screen.currentResolution.height);
        gameData.isFullScreen = PlayerPrefs.GetInt("isFullScreen", Screen.fullScreen ? 1: 0) == 1;

        // Load Set Volume Data
        gameData.gameVol = PlayerPrefs.GetFloat("gameVol", 0.5f);
        gameData.musicVol = PlayerPrefs.GetFloat("musicVol", 0.5f);
        gameData.effectVol = PlayerPrefs.GetFloat("effectVol", 0.5f);

        // Load Framd Rate Data
        gameData.setFrame = PlayerPrefs.GetInt("setFrame", 60);
    }

    void Init()
    {
        // Static Objects Initialization

        // Game Data Load

        // 
    }

    void SaveData()
    {
        PlayerPrefs.Save();
    }

    public void PauseGame()
    {
        if (!isPause)
        {
            Time.timeScale = 0f;
            isPause = true;
            // Pause UI Spawn
        }
        else
        {
            Time.timeScale = 1f;
            isPause = false;
            // Pause UI Despawn
        }
    }

    public void GameStart()
    {
        // Game Start Action
    }

    public void GameEnd()
    {
        // Game End Action
    }

    public void StageStart()
    {
        // if Stage Game, stage start Action
    }

    public void StageEnd()
    {
        // if Stage Game, stage end Action
    }
}
