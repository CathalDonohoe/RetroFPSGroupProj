﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTestController : MonoBehaviour
{


    public int health = 3;
    public GameObject explosion;

    public float playerRange = 30f;

    public Rigidbody2D theRB;
    public float moveSpeed;

    public bool shouldShoot;
    public float fireRate = .5f;
    private float shotCounter;
    public GameObject bullet;
    public Transform firepoint;
    public static int enemyKilledCount = 0;

    public int damageAmount;

    public static bool isShot=false;

    


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, PlayerController.instance.transform.position) < playerRange)
        {
            Vector3 playerDirection = PlayerController.instance.transform.position - transform.position;

            theRB.velocity = playerDirection.normalized * moveSpeed;

            if(shouldShoot)
            {
                shotCounter -= Time.deltaTime;
                if(shotCounter <= 0)
                {
                    Instantiate(bullet, firepoint.position, firepoint.rotation);
                    shotCounter = fireRate;
                    SoundController.instance.PlayEnemyFire();
                    
                }
            }
        }
        else
        {
            theRB.velocity = Vector2.zero;

        }
        
    }


    public void takeDamage()
    {
        health--;

        if (health <= 0)
        {

            Destroy(gameObject);
            Instantiate(explosion, transform.position, transform.rotation);
            enemyKilledCount++;

            SoundController.instance.PlayEnemyDeath();
        } else
        {
            isShot = true;
            SoundController.instance.PlayEnemyShot();
            
        }
        
        
        
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {
            PlayerController.instance.takeDamage(damageAmount);
        }
    }
}
