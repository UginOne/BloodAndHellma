﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerAnimationScript : MonoBehaviour {
                               
    //ссылка на компонент анимаций
    private Animator anim;
    public GameObject playerHand;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();  

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            fire();
        }
    }

    void fire()
    {
        anim.SetFloat("Punch", 2);
                                                                     
    }
}