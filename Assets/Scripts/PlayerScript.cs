using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour {

    [SerializeField]
    float moveSpeed = 4f;
    private Vector2 direction;
                                 

    // Use this for initialization
    void Start()
    {                                      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.anyKey)
            Move();                              
    }

    void Move()
    {
        Vector3 movement = new Vector3(moveSpeed * Time.deltaTime * Input.GetAxis("HorizontalKey"),
            moveSpeed * Time.deltaTime * Input.GetAxis("VerticalKey"),
            0);

        transform.Translate(movement);   
    }
}
