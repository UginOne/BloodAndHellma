using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWallScript : MonoBehaviour, IDestroyable
{

    public Sprite destroyedSprite;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Hit()
    {
        Destroy();
    }

    public void Destroy()
    {
        if (destroyedSprite != null)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
