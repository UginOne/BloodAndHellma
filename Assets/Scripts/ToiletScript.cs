using Assets.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    public class ToiletScript : MonoBehaviour, IDestroyable
    {
        public Sprite destroyedSprite;
        public Sprite hittedSprite;
        private bool destroyed = false;
        private bool hitted = false;

        void Start()
        {
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject != null && collision.gameObject.tag == "weapon")
            {
                Hit();
            }
        }

        public void Hit() {
            if (!hitted && hittedSprite != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = hittedSprite;
                hitted = true;
            }
            else if (hitted)
                Destroy();
        }

        public void Destroy() {
            if (!destroyed && destroyedSprite != null)
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = destroyedSprite;
                gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                destroyed = true;
            }
        }
    }
}
