using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadScreenManager : MonoBehaviour
{
    public void Quit()
    {
        print("quit");
        Application.Quit();
    }

    public void Restart()
    {
        print("menu");
        Application.LoadLevel(Application.loadedLevel);
    }
    public void ButtonClickedQ()
    {
        Debug.Log("in ButtonClicked");
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
