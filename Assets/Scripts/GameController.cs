using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enemyCount;

    public static float levelTime;
    public static float finalLevelTime;

    private bool levelComplete;
    
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
        if (EnemyController.enemyKilledCount == enemyCount)
        {
            // Debug.Log("enemyCount + " + enemyCount);
            // Debug.Log("enemyKilledCount + " + EnemyController.enemyKilledCount);
            finalLevelTime = levelTime;
            SceneManager.LoadScene("LevelComplete", LoadSceneMode.Single);
            levelComplete = true;

        }
        else if (levelComplete == false)
        {
            levelTime += Time.deltaTime;
        }
    }
}