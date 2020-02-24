using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillBoard : MonoBehaviour
{
    private SpriteRenderer theSR;
    // Start is called before the first frame update
    void Start()
    {
        theSR = GetComponent<SpriteRenderer>();
        theSR.flipX = true;
    }

    // Update is called once per frame
    void Update()
    {
        //  objects point towards player
        transform.LookAt(PlayerController.instance.transform.position, -Vector3.back);
    }
}
