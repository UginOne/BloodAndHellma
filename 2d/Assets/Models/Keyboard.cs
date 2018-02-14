using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;

namespace Assets.Models
{
    public class Keyboard : IWeapon
    {
        public Keyboard()
        {
            weapon = 0; //оружие в списке

            bulletSpeed = 0;

            shootCount = 1; // обоима, например

            currentShootCount = 1; // выстрелов одновременно, например

            accuracy = 1; // разброс пуль, 1 = 100% точности

            isMelee = true;

            ammo = int.MaxValue;

            reloadTimeOut = 0;

            fireRate = 0;

            shotBulletCount = 0;
        }

        public int weapon { get; set; }
        public float bulletSpeed { get; set; }
        public int shootCount { get; set; }
        public int currentShootCount { get; set; }
        public float accuracy { get; set; }
        public bool isMelee { get; set; }
        public int ammo { get; set; }
        public float reloadTimeOut { get; set; }
        public float fireRate { get; set; }

        public int shotBulletCount { get; set; }
    }
}
