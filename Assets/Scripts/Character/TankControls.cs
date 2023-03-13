using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankControls : MonoBehaviour
{

    public static bool isMoving = false;
    public static bool canMove = true;
    public static bool isBackingUp = false;
    public static bool isRotating = false;
    public static bool isRunning = false;


    public float horizontalMove;
    public float verticalMove;

    void Update()
    {
        if (canMove)
        {
            if (!WeaponMechanics.isAiming && !PauseMenu.gamePaused && !InventoryControl.isOpen && !Health.playerDead)
            {
                if ((Input.GetButton("Horizontal") || Input.GetButton("Vertical")) && (!(PlayerKnockback.isGettingHit || PlayerKnockback.isGettingBit || Health.playerDead)))
                {
                    isMoving = true;
                    /*Debug.Log("isMoving = " + isMoving);*/
                    if (Input.GetButton("DKey") && (!(Input.GetButton("SKey") || Input.GetButton("WKey"))))
                    {
                        isRotating = true;
                        /*Debug.Log("isRotating = " + isRotating);*/
                        isRunning = false;
                        isBackingUp = false;
                        this.GetComponent<Animator>().Play("Right Rotate");
                    }
                    else if (Input.GetButton("AKey") && (!(Input.GetButton("SKey") || Input.GetButton("WKey"))))
                    {
                        isRotating = true;
                        /*Debug.Log("isRotating = " + isRotating);*/
                        isRunning = false;
                        isBackingUp = false;
                        this.GetComponent<Animator>().Play("Left Rotate");
                    }
                    else if (Input.GetButton("SKey"))
                    {
                        isBackingUp = true;
                        /*Debug.Log("isBackingUp = " + isBackingUp);*/
                        isRunning = false;
                        isRotating = false;
                        this.GetComponent<Animator>().Play("Walk Backward");
                    }
                    else if (Input.GetKey(KeyCode.LeftShift) && !(Input.GetButton("SKey")))
                    {
                        isRunning = true;
                        /*Debug.Log("isRunning = " + isRunning);*/
                        isBackingUp = false;
                        isRotating = false;
                        this.GetComponent<Animator>().Play("Run Forward");
                        verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 2.5f;
                        this.transform.Translate(0, 0, verticalMove);
                    }
                    else
                    {
                        isRunning = false;
                        isBackingUp = false;
                        isRotating = false;
                        this.GetComponent<Animator>().Play("Walk Forward");
                    }
                    horizontalMove = Input.GetAxis("Horizontal") * Time.deltaTime * 150;
                    verticalMove = Input.GetAxis("Vertical") * Time.deltaTime * 4.5f;
                    this.transform.Rotate(0, horizontalMove, 0);
                    this.transform.Translate(0, 0, verticalMove);
                }

                else
                {
                    if (PlayerKnockback.isGettingHit)
                    {
                        isMoving = false;
                        isRotating = false;
                        isRunning = false;
                        isBackingUp = false;
                    }
                    if (!PlayerKnockback.isGettingHit && !Health.playerDead)
                    {
                        isMoving = false;
                        isRotating = false;
                        isRunning = false;
                        isBackingUp = false;
                        this.GetComponent<Animator>().Play("Idle");
                    }
                }
            }
        }
    }
}
