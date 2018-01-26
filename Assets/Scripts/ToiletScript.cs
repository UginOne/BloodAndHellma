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

        void Start()
        {
        }

        public void Hit() { }

        public void Destroy() { }
    }
}
