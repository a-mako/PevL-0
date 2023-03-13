using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitPlayer : MonoBehaviour
{
    public float damagePoints = 100f;
    public AudioSource gushySound;
    public static bool playerHit;

    private void OnTriggerStay(Collider other)
    {
        Health H = other.GetComponent<Health>();

        if (H == null) return;

        if (EnemyMovement.isAttacking)
        {
            if (!gushySound.isPlaying)
            {
                gushySound.Play();
            }
            H.healthPoints -= damagePoints * Time.deltaTime;
            playerHit = true;
        }
    }
}
