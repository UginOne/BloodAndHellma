using System;                       
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

    public GameObject bullet;

    [SerializeField]
    float bulletSpeed = 10f;
    [SerializeField]
    [Range(1, 5)]
    private int shootCount = 4; // выстрелов одновременно, например
    [Range(1, 5)]
    private int currentShootCount = 0; // выстрелов одновременно, например
    [SerializeField]
    [Range(0.9f, 1f)]
    private float accuracy = 1; // разброс пуль, 1 = 100% точности
                       
                                // Use this for initialization
    void Start ()
	{
	    anim = player.transform.GetComponent<Animator>();

	    var dropDown = transform.GetComponent<Dropdown>();
	    dropDown.onValueChanged.AddListener(delegate {
	        DropdownValueChanged(dropDown);
	    });
    }

    //Ouput the new value of the Dropdown into Text
    void DropdownValueChanged(Dropdown change)
    {                             
        anim.SetInteger("Weapon", change.value);
        switch (change.value)
        {
            case 0: Global.weapon = Global.allWeapon.axe;
                player.gameObject.GetComponent<SpriteRenderer>().sprite = axeSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = false;
                break;
            case 1:
                Global.weapon = Global.allWeapon.shotGun;
                player.gameObject.GetComponent<SpriteRenderer>().sprite = shotGunSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                break;
            case 2:
                Global.weapon = Global.allWeapon.machineGun;
                player.gameObject.GetComponent<SpriteRenderer>().sprite = machineGunSprite;
                player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
                player.gameObject.GetComponent<EdgeCollider2D>().enabled = true;
                break;
        }
        
    }

    void FixedUpdate()
    {
        if (Global.weapon == Global.allWeapon.machineGun || Global.weapon == Global.allWeapon.shotGun)
        {
            if (Input.GetButtonDown("Fire1"))
            {
                fire();
            }
        }
    }

    void fire()
    {
        //загрузить настройки оружия                  
        if (player == null) return;

       var  weapon = player.transform.Find("PlayerHand");

        if (weapon == null) return;
        currentShootCount = 0;
                                                      
        var firstBullet = Instantiate(bullet, weapon.transform.position, weapon.rotation);
        var direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - weapon.transform.position +
                        (Vector3)(Random.insideUnitCircle * (1f - accuracy));
        firstBullet.GetComponent<Rigidbody2D>().AddForce(direction, ForceMode2D.Impulse);

    }
}
