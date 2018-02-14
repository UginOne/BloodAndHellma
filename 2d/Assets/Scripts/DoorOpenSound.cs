using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenSound : MonoBehaviour
{

    public AudioClip doorOpenSound;

    private AudioSource source;
    private float currentAngle;
    private bool opened;
    // Use this for initialization
    void Awake()
    {
        source = GetComponent<AudioSource>();
        opened = false;
    }
    
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (!opened)
        {
            source.PlayOneShot(doorOpenSound, 0.4F);
        }
        opened = true;
    }
}