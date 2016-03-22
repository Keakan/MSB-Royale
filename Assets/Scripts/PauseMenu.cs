using System;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    //public Toggle m_MenuToggle;
    public GameObject MenuParent;
    public GameObject TopMenu;
    public GameObject Fader;
    public GameObject OptionsMenu;
    private float m_TimeScaleRef = 1f;
    private float m_VolumeRef = 1f;
    public bool isPaused;

    public void Start()
    {
        MenuParent.SetActive(false);
        TopMenu.SetActive(false);
        Fader.SetActive(false);
        OptionsMenu.SetActive(false);
    }

    public void Update()
    {
        if (Input.GetButton("Start"))
        {
            //if (isPaused == true) { MenuOff(); }
            //else if (isPaused == false)
            //{
            //MenuOn();
            //}
            isPaused = true;
                //!isPaused;
        }
        if (isPaused)
        {
            MenuOn();
        }
        else
        {
            MenuOff();
        }
    }
    private void MenuOn()
    {
        MenuParent.SetActive(true);
        TopMenu.SetActive(true);
        Fader.SetActive(true);
        //OptionsMenu.SetActive(false);

        m_TimeScaleRef = Time.timeScale;
        Time.timeScale = 0f;

        m_VolumeRef = AudioListener.volume;
        AudioListener.volume = 0f;

        isPaused = true;
    }

    public void MenuOff()
    {
        MenuParent.SetActive(false);
        TopMenu.SetActive(false);
        Fader.SetActive(false);

        m_TimeScaleRef = 1f;
        Time.timeScale = m_TimeScaleRef;
        AudioListener.volume = m_VolumeRef;

        isPaused = false;
    }
    public void Options()
    {
        OptionsMenu.SetActive(true);
        MenuParent.SetActive(false);
        TopMenu.SetActive(false);
        Fader.SetActive(false);
    }
    public void OptionsBack()
    {
        OptionsMenu.SetActive(false);
        TopMenu.SetActive(true);
    }
}
