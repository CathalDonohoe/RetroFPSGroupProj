﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D theRB;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;

    public Camera viewCam;


    public GameObject bulletImpact;

    public int currentAmmo;


    public Animator gunAnim;
    public Animator anim;

    public int currentHealth;
    public int maxHealth = 100;
    public GameObject deadScreen;
    private bool hasDied;

    public Text healthText, ammoText, enemyText;

    bool waitActive = false;




    private void Awake() {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        updateEnemyUI(); 
        currentHealth = maxHealth;
        healthText.text = currentHealth.ToString();

        ammoText.text = currentAmmo.ToString();
    }

    // Update is called once per frame
    void Update()
    {
       if(!hasDied) 
       {
            //player movement for a 2d environment
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

            Vector3 moveHorizontal = transform.up * -moveInput.x;
            Vector3 moveVertical = transform.right * moveInput.y;

            theRB.velocity = (moveHorizontal + moveVertical) * moveSpeed;

            //camera control

            mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"),Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - mouseInput.x);

            viewCam.transform.localRotation = Quaternion.Euler(viewCam.transform.localRotation.eulerAngles + new Vector3(0f, mouseInput.y, 0f));


            //shooting area
            if(Input.GetMouseButtonDown(0))
            {
                if(currentAmmo > 0)
                {

                    
                    Ray ray = viewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
                    RaycastHit hit;
                    if (Physics.Raycast(ray, out hit))
                    {
                        //Debug.Log("Im looking at " + hit.transform.name);
                        Instantiate(bulletImpact, hit.point, transform.rotation);

                        if(hit.transform.tag == "Enemy")
                        {
                            hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                            updateEnemyUI();                    
                        }
                        
                        
                    }
                    else{
                        //Debug.Log("Im looking at nothing");
                    }
                    currentAmmo--;
                    gunAnim.SetTrigger("Shoot");
                    updateAmmoUI();
                }
            }

            if(moveInput != Vector2.zero)
            {
                anim.SetBool("isMoving", true);
            }
            else
            {
                anim.SetBool("isMoving", false);
            }
       }

    }

    public void takeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        if(currentHealth <= 0)
        {
            hasDied = true;
            //if(hasDied == true)
            //{
                //Cursor.lockState = CursorLockMode.None;
                //Cursor.visible = true;
                //deadScreen.SetActive(true);
                
            //}

            if (!waitActive)
            {
                deadScreen.SetActive(true); 
            }
            
            Application.LoadLevel(Application.loadedLevel);
            currentAmmo = 25;
            currentHealth = 100;
            
        }
        healthText.text = currentHealth.ToString();
    }

    public void addHealth(int healAmount)
    {
        currentHealth += healAmount;
        if(currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthText.text = currentHealth.ToString();
    }

    public void updateAmmoUI()
    {
        ammoText.text = currentAmmo.ToString();
    }

    public void updateEnemyUI()
    {
        enemyText.text = GameObject.FindGameObjectsWithTag("Enemy").Length.ToString();
    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds (3.0f);
        waitActive = false;
    }
}
