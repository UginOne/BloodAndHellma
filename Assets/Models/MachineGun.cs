﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Assets.Interfaces;

namespace Assets.Models
{
    public class MachineGun : IWeapon
    {
        public MachineGun()
        { 
            weapon = 2; //оружие в списке

            bulletSpeed = 10f;

            shootCount = 30; // обоима, например

            currentShootCount = 30; // выстрелов одновременно, например

            accuracy = 0.9f; // разброс пуль, 1 = 100% точности

            isMelee = false;

            ammo = 120;

            reloadTimeOut = 2;

            fireRate = 0.1f;
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
    }
}
