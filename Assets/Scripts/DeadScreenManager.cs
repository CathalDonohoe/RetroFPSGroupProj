using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class DeadScreenManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClickedQ()
    {
        Debug.Log("in ButtonClicked");
        SceneManager.LoadSceneAsync("MainMenu", LoadSceneMode.Single);
    }
}
