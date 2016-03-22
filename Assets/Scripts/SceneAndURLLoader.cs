using System;
using UnityEngine;

public class SceneAndURLLoader : MonoBehaviour
{
    private PauseMenu m_PauseMenu;

    private void Awake ()
    {
        m_PauseMenu = GetComponentInChildren <PauseMenu> ();
    }
    public void SceneLoad(string sceneName)
    {
        m_PauseMenu.MenuOff();
        if (sceneName == "current")
        {
            Application.LoadLevel(Application.loadedLevelName);
        }
        else
        {
            //PauseMenu pauseMenu = (PauseMenu)FindObjectOfType(typeof(PauseMenu));
            Application.LoadLevel(sceneName);
        }
    }
    public void MainSceneLoad(string sceneName)
    {
        Application.LoadLevel(sceneName);
    }
    public void LoadURL(string url)
	{
		Application.OpenURL(url);
	}
    public void Exit()
    {
        Application.Quit();
    }
}

