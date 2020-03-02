using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static PlayerController instance;

    public Rigidbody2D rb;

    public float moveSpeed = 5f;

    private Vector2 moveInput;
    private Vector2 mouseInput;

    public float mouseSensitivity = 1f;


    public Camera ViewCam;

    public GameObject bulletImpact;
    public int currentAmmo;

    public Animator gunAnim;

    private void Awake() 
    {
        instance = this;
    }

    //  Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //  player movement
        moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        Vector3 moveHorizontal = transform.up * moveInput.x;

        Vector3 moveVertical = transform.right * moveInput.y;

        rb.velocity = (moveHorizontal + moveVertical) * moveSpeed;


        //  player view control
        mouseInput = new Vector2(Input.GetAxisRaw("Mouse X"), Input.GetAxisRaw("Mouse Y")) * mouseSensitivity;

        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + mouseInput.x);


        ViewCam.transform.localRotation = Quaternion.Euler(ViewCam.transform.localRotation.eulerAngles - new Vector3(0f, mouseInput.y, 0f));

        //  player shooting
        if(Input.GetMouseButtonDown(0)) {
            if(currentAmmo > 0) {
            Ray ray = ViewCam.ViewportPointToRay(new Vector3(.5f, .5f, 0f));
            RaycastHit hit;

            //  if somethings is hit
            if(Physics.Raycast(ray, out hit)) {
                //Debug.Log("Looking at " + hit.transform.name);
                Instantiate(bulletImpact, hit.point, transform.rotation);

                if(hit.transform.tag == "Enemy")
                    {
                        hit.transform.parent.GetComponent<EnemyController>().takeDamage();
                    }

            } else {
                Debug.Log("Looking at nothing");
            }
                currentAmmo--;
                gunAnim.SetTrigger("Shoot");
            }
        }
    }
}
