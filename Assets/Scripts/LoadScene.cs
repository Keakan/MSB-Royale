﻿using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {
    
    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
    }
    public void LoadLevel(int l)
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
