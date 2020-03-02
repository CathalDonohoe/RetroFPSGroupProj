using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{


    public int health = 3;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void takeDamage()
    {
        health--;

        if (health <= 0)
        {
            Debug.Log("entered if");
            Destroy(gameObject);

        }

        else {
                Debug.Log("fucked up");
            }
    }
}
