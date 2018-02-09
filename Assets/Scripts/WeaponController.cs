using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Timers;
using Assets.Interfaces;
using Assets.Models;
using Assets.Scripts;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class WeaponController : MonoBehaviour
{

    private Animator anim;
    public Sprite axeSprite;
    public Sprite shotGunSprite;
    public Sprite machineGunSprite;
    public GameObject player;
    public GameObject weaponInfo;
    public Text weaponInfoText;

    public GameObject bullet;

    public IWeapon CurrentWeapon;

    public IEnumerable<IWeapon> weaponList;

    private float fireRateTimeout;

    private bool TimerEnabled;

    private float reloadTime = 0;

    // Use this for initialization
    void Start ()
	{ 

	    anim = player.transform.GetComponent<Animator>();

        CurrentWeapon = new Keyboard();

        weaponList = new List<IWeapon> { CurrentWeapon,new ShotGun(), new MachineGun()};

	    var dropDown = transform.GetComponent<Dropdown>();

	    dropDown.onValueChanged.AddListener(delegate {
	        DropdownValueChanged(dropDown);
	    });

	    fireRateTimeout = 0;

	    weaponInfoText = weaponInfo.GetComponent<Text>();
	    weaponInfoText.text = "1 / 1";
	    TimerEnabled = false;
	}

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {                             
        anim.SetInteger("Weapon", change.value);   
        switch (change.value)
        {
            case 0: 
                player.gameObject.GetComponent<SpriteRenderer>().sprite = axeSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                CurrentWeapon = weaponList.FirstOrDefault(a => a.weapon == 0);
                break;
            case 1:                                         
                player.gameObject.GetComponent<SpriteRenderer>().sprite = shotGunSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                CurrentWeapon = weaponList.FirstOrDefault(a => a.weapon == 1);
                break;
            case 2:                                           
                player.gameObject.GetComponent<SpriteRenderer>().sprite = machineGunSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                CurrentWeapon = weaponList.FirstOrDefault(a => a.weapon == 2);
                break;
        }
        loadWeaponInfoText();
    }

    void loadWeaponInfoText()
    {
        if (CurrentWeapon == null)
        {
            weaponInfoText.text = "0 / 0";
            return ;
        }
        weaponInfoText.text = string.Format("{0} / {1}", CurrentWeapon.currentShootCount, CurrentWeapon.ammo);
    }

    void FixedUpdate()
    {
        if (CurrentWeapon == null)
        {
            return;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            FinishFire();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            if (CurrentWeapon.isMelee)
            {

                anim.SetFloat("Punch", 2);   
            }
            else
            {
                StartFire(); 
            }
        } 
    }

    void fire()
    {
      
            if (player == null) return;

            anim.SetFloat("Punch", 2);
            var weapon = player.transform.Find("PlayerHand");

            if (weapon == null) return;
            var x = weapon.transform.position.x - player.transform.position.x;
            var y = weapon.transform.position.y - player.transform.position.y;
            var bulletForce = new Vector2(x, y);
        for (var i = 0; i < CurrentWeapon.shotBulletCount; i++)
        { 
            bulletForce = bulletForce + (Random.insideUnitCircle * (1 - CurrentWeapon.accuracy));
            var firstBullet = Instantiate(bullet, weapon.transform.position, weapon.rotation) ;
            firstBullet.GetComponent<Rigidbody2D>().AddForce(bulletForce);
        }                                                                         
            CurrentWeapon.currentShootCount -= 1;

            fireRateTimeout = 0;
            loadWeaponInfoText(); 
    }

    bool isPresed;

    public void StartFire()
    {
        isPresed = true;
    }

    public void FinishFire()
    {
        isPresed = false;
    }

    public void Update()
    {
        if (CurrentWeapon.currentShootCount <= 0)
        {                        
            reloadTime += Time.deltaTime;
            if (reloadTime > CurrentWeapon.reloadTimeOut)
            {
                WeaponReload();
            }
        }
        else
        {
            if (TimerEnabled)
            {
                return;
            }

            fireRateTimeout += Time.deltaTime;
            if (fireRateTimeout > CurrentWeapon.fireRate && isPresed)
            {
                fireRateTimeout = 0;
                fire();
            }
        }
    }

    private void WeaponReload()
    {
        reloadTime = 0;
        if (CurrentWeapon.currentShootCount == 0 && CurrentWeapon.ammo > 0)
        {                    
            // перезарядка завершена
            CurrentWeapon.currentShootCount = CurrentWeapon.shootCount;

            CurrentWeapon.ammo = CurrentWeapon.ammo - CurrentWeapon.shootCount;

            if (CurrentWeapon == null)
            {
                weaponInfoText.text = "0 / 0";
                return;
            }
            weaponInfoText.text = string.Format("{0} / {1}", CurrentWeapon.currentShootCount, CurrentWeapon.ammo);
        }                     
    }
}
