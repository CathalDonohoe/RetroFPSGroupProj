using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spriteChanger : MonoBehaviour
{

    public Sprite enemyIdle;
    public Sprite enemyShot;

    bool waitActive = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(EnemyController.isShot == true)
        {
            print("Enemy shot");
            gameObject.GetComponent<SpriteRenderer> ().sprite = enemyShot;
            
        }

        if(EnemyController.isShot == false)
        {
            gameObject.GetComponent<SpriteRenderer> ().sprite = enemyIdle;
            //print("enemy not shot");
        }

    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds (2.0f);
        waitActive = false;
    }
}
