using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

    public Texture backgroundTexture;

    void OnGUI()
    {
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);

        GUI.Button(new Rect(Screen.width * .6f, Screen.height * .5f, Screen.width * .4f, Screen.height * .1f), "PLAY");
        GUI.Button(new Rect(Screen.width * .6f, Screen.height * .6f, Screen.width * .4f, Screen.height * .1f), "OPTIONS");
        GUI.Button(new Rect(Screen.width * .6f, Screen.height * .7f, Screen.width * .4f, Screen.height * .1f), "EXIT");
    }
}
