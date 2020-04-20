using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enemyCount;
    public int enemy2Count;

    public static float levelTime;
    public static float finalLevelTime;

    private bool levelComplete;

    public GameObject LoadingScreen;
    
    
    // Start is called before the first frame update
    void Start()
    {
        levelComplete = false;
    }

    // Update is called once per frame
    void Update()
    {
        LevelPassed();

       if (Input.GetKeyDown(KeyCode.Escape))
        {
           unlockCursor();
        }
        if (levelComplete == false)
        {
            if (Input.GetMouseButton(0))
            {
                lockCursor();
            }
        }
    }


    private void lockCursor()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void unlockCursor()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    

    public void LevelPassed()
    {
        Scene currentScene = SceneManager.GetActiveScene();

        string sceneName = currentScene.name;

        if (sceneName == "Level1")
        {
            Debug.Log("Level 1");
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LoadingScreen.SetActive(true);
                finalLevelTime = levelTime;
                levelComplete = true;

                SceneManager.UnloadScene("Level1");

                SceneManager.LoadScene("LevelComplete");
        
            }
            else if (levelComplete == false)
            {
                levelTime += Time.deltaTime;
            }
        }

        else if (sceneName == "Level2")
        {
            Debug.Log("inscene2");
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LoadingScreen.SetActive(true);
                finalLevelTime = levelTime;
                levelComplete = true;

                SceneManager.LoadScene("Level2Complete");
        
            }
            else if (levelComplete == false)
            {
                levelTime += Time.deltaTime;
            }
        }

        else if (sceneName == "Level3")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LoadingScreen.SetActive(true);
                finalLevelTime = levelTime;
                levelComplete = true;

                SceneManager.LoadScene("Complete");
        
            }
            else if (levelComplete == false)
            {
                levelTime += Time.deltaTime;
            }
        }
        
    }
}