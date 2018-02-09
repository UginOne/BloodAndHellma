using Assets.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassWallScript : MonoBehaviour, IDestroyable
{

    public Sprite destroyedSprite;
    private bool destroyed = false;

	// Use this for initialization
	void Start ()
	{
	    HitPoint = 1;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter2D(Collision2D collision)
    {                                       
        if (collision.gameObject != null && collision.gameObject.tag == "weapon")
        {
            Hit();  
        }
    }

    public int HitPoint { get; set; }

    public void Hit()
    {                              
        Destroy();
    }

    public void Hit(int damage)
    {
        Destroy();
    }

    public void Destroy()
    {                             
        if (!destroyed && destroyedSprite != null)
        {                             
            gameObject.GetComponent<SpriteRenderer>().sprite = destroyedSprite;
            gameObject.GetComponent<BoxCollider2D>().enabled = false;
            destroyed = true;
        }
    }
}
