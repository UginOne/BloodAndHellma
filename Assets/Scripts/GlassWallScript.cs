using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWallScript : MonoBehaviour, IDestroyable
{

    public Sprite destroyedSprite;
    private GameObject currentObject;

	// Use this for initialization
	void Start () {
		currentObject = gameObject;
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
            currentObject.GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            currentObject.GetComponent<BoxCollider2D>().enabled = false;
        }
    }
}
