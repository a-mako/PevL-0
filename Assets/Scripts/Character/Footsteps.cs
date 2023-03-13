using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footsteps : MonoBehaviour
{
    public AudioSource footstepSound, runningStepSound;

    private void Update()
    {
        if ((TankControls.isMoving || TankControls.isRotating) && (!(WeaponMechanics.isAiming || TankControls.isRunning)) && !PauseMenu.gamePaused && !InventoryControl.isOpen && !PlayerKnockback.isGettingHit && !Health.playerDead)
        {
            runningStepSound.enabled = false;
            footstepSound.enabled = true;
        }

        else if ((TankControls.isRunning) && (!WeaponMechanics.isAiming) && !PauseMenu.gamePaused && !InventoryControl.isOpen && !PlayerKnockback.isGettingHit && !Health.playerDead)
        {
            footstepSound.enabled = false;
            runningStepSound.enabled = true;
        }
        else
        {
            footstepSound.enabled = false;
            runningStepSound.enabled = false;
        }
    }
}
