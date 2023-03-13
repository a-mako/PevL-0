using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    Animator animator;

    public float waitForSeconds = .5f;
    public float speed = 1.5f;

    public static bool isGettingHit = false;
    public static bool isGettingBit = false;



    void Start()
    {
        animator = this.GetComponent<Animator>();
    }
    void Update()
    {
        if (EnemyMovement.isAttacking && HitPlayer.playerHit && !Health.playerDead)
        {
            isGettingHit = true;
            TankControls.canMove = false;
            StartCoroutine(KnockBack());
        }

        if (Health.playerDead)
        {
            isGettingHit = false;
            StartCoroutine(Death());
        }
    }

    IEnumerator KnockBack()
    {
        yield return new WaitForSeconds(.45f);
        animator.SetTrigger("Hit");
        BoxCollider boxCol = this.GetComponent<BoxCollider>();
        if (VisionCast.facingZombie)
        {
            boxCol.transform.position += speed * Time.deltaTime * (-(transform.forward)) * .75f;
        }
        else
        {
            boxCol.transform.position += speed * Time.deltaTime * (transform.forward) * .75f;
        }
        yield return new WaitForSeconds(waitForSeconds);
        isGettingHit = false;
        TankControls.canMove = true;
        HitPlayer.playerHit = false;
    }

    IEnumerator Death()
    {
        yield return new WaitForSeconds(2f);
        animator.SetTrigger("Death");
    }
}
