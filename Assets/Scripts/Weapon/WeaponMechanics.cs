using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMechanics : MonoBehaviour
{
    public GameObject player;
    public GameObject weapon;
    public GameObject weaponPointer;

    public AudioSource gunShot;

    public float horizontalMove;
    public float fireRate = 2f;


    public static float shotRate;

    public static bool isShooting = false;

    public static bool weaponEquipped = false;
    public static bool isAiming = false;

    public void Start()
    {
        shotRate = fireRate;
    }
    private void Update()
    {

        if (weapon.activeSelf)
        {
            weaponEquipped = true;
            /*Debug.Log("WeaponEquipped:" + weaponEquipped);*/
        }

        else
        {
            weaponEquipped = false;
        }

        if (weaponEquipped && weaponPointer.activeSelf && !Health.playerDead && !PauseMenu.gamePaused && !InventoryControl.isOpen)
        {
            if (PlayerKnockback.isGettingHit || Health.playerDead)
            {
                isAiming = false;
            }
            else if (Input.GetMouseButtonDown(1))
            {
                isAiming = true;
                player.GetComponent<Animator>().Play("Aim");
                weaponPointer.SetActive(true);
                /*player.GetComponent<AutoAim>().enabled = true;
                AutoAim.autoAim = true;*/
            }

            if (Input.GetMouseButtonUp(1) || !Input.GetKey(KeyCode.Mouse1))
            {
                if (isShooting)
                {
                    //do nothing
                }
                else
                {
                    isAiming = false;
                    /*AutoAim.autoAim = false;*/
                    /*player.GetComponent<AutoAim>().enabled = false;*/
                }
            }

            if (isAiming && !isShooting && !PlayerKnockback.isGettingHit && !Health.playerDead)
            {
                if (Input.GetButton("Horizontal"))
                {
                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                    player.transform.Rotate(0, horizontalMove, 0);
                }

                if (Input.GetMouseButtonDown(0))
                {
                    if (PistolCast.onTarget)
                    {
                        PistolCast.hitTarget = true;
                    }
                    else
                    {
                        PistolCast.hitTarget = false;
                    }
                    StartCoroutine(ShootWeapon());
                }
            }
        }
    }

    IEnumerator ShootWeapon()
    {
        isShooting = true;
        weaponPointer.SetActive(false);
        player.GetComponent<Animator>().Play("Shoot");
        gunShot.Play();
        yield return new WaitForSeconds(fireRate);
        isShooting = false;
        PistolCast.hitTarget = false;
        weaponPointer.SetActive(true); 
        player.GetComponent<Animator>().Play("Aim");
    }
}
