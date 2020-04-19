using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Complete : MonoBehaviour
{
    public void Menu(){
        SceneManager.LoadScene("MainMenu");
    }

    public void Quit(){
        Application.Quit();
    }
}
