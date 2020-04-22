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
    public static float finalGameTime=10;

    private bool levelComplete;

    public static bool level1Completed, level2Completed, level3Completed = false;
    public static float level1Time, level2Time, level3Time = 0;

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

        // Level 1
        if (sceneName == "Level1")
        {
            Debug.Log("Level 1");

            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LoadingScreen.SetActive(true);
                finalLevelTime = levelTime;

                finalGameTime += finalLevelTime;

                levelComplete = true;
                level1Completed = true;

                SceneManager.LoadSceneAsync("LevelComplete", LoadSceneMode.Single);
                levelComplete = true;

                SceneManager.LoadSceneAsync("LevelComplete");
        

            }
            else if (levelComplete == false)
            {
                levelTime += Time.deltaTime;
            }
        }

        //  Level 2
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

        // Level 3
        else if (sceneName == "Level3")
        {
            if (GameObject.FindGameObjectsWithTag("Enemy").Length == 0)
            {
                LoadingScreen.SetActive(true);
                finalLevelTime = levelTime;

                finalGameTime += finalLevelTime;

                levelComplete = true;
                level3Completed = true;

                if (level1Completed && level2Completed && level3Completed)
                {
                    // Displays total time taken to player
                    finalLevelTime = finalGameTime;
                    levelTime = finalGameTime;
                    SceneManager.LoadSceneAsync("Complete", LoadSceneMode.Single);
                }
                else
                {
					level1Completed = false;
					level2Completed = false;
					level3Completed = false;
                    finalGameTime = 0;
                    // Displays level time to player
                    SceneManager.LoadSceneAsync("Level3Complete", LoadSceneMode.Single);
                }

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
