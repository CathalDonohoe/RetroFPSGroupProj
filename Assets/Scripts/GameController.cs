using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public int enemyCount;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        LevelPassed();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            unlockCursor();
        }

        if (Input.GetMouseButton(0))
        {
            lockCursor();
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
        //if (EnemyController.enemyKilledCount == enemyCount)
        if (EnemyController.enemyKilledCount == 1)
        {
            Debug.Log("enemyCount + " + enemyCount);
            Debug.Log("enemyKilledCount + " + EnemyController.enemyKilledCount);
            SceneManager.LoadSceneAsync("LevelComplete", LoadSceneMode.Additive);
            EnemyController.enemyKilledCount--;
        }
    }
}