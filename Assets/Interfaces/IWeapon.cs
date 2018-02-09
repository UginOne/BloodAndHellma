using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Interfaces
{   
    public interface IWeapon
    {
        /// <summary>
        /// поярдковый номер оружия
        /// </summary>
        int weapon { get; set; }

        /// <summary>
        /// Скорость полета пули
        /// </summary>
        float bulletSpeed { get; set; }

        /// <summary>
        /// Обоима
        /// </summary>
        int shootCount { get; set; }

        /// <summary>
        /// текущее состояние обоимы
        /// </summary>
        int currentShootCount { get; set; }  

        /// <summary>
        /// точность
        /// </summary>
        float accuracy { get; set; }  

        /// <summary>
        /// Оружие ближнего боя
        /// </summary>
        bool isMelee { get; set; }  

        /// <summary>
        /// Полное количество патронов
        /// </summary>
        int ammo { get; set; }

        /// <summary>
        /// Время перезарядки
        /// </summary>
        float reloadTimeOut { get; set; }

        /// <summary>
        /// скорострельность
        /// </summary>
        float fireRate { get; set; }
    }
}
