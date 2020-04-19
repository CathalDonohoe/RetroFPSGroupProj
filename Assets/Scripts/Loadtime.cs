using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Loadtime : MonoBehaviour
{
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;
    [SerializeField]
    private float delayBeforeLoading = 2f;

    void Update()
    {

        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        timeElapsed += Time.deltaTime;

        if (sceneName == "LevelComplete")
        {
            
            if(timeElapsed > delayBeforeLoading)
            {
                SceneManager.LoadScene("Level2");
            }
        }
        
        else if (sceneName == "Level2Complete")
        {
            if(timeElapsed > delayBeforeLoading)
            {
                SceneManager.LoadScene("Level3");
            }
        }
        
    }
}
