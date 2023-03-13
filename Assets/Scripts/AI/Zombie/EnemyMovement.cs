using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMovement : MonoBehaviour
{
    private GameObject target;

    [SerializeField] public float chaseThreshold = 20f;
    [SerializeField] public float attackThreshold = 6f;

    public AudioSource staggerSteps;

    public Animator animator;

    public enum AIState { idle, chasing, attacking, takingDamage, betweenAttack};
    public AIState aiState = AIState.idle;

    NavMeshAgent navAgent;

    public static bool isTakingDamage = false;
    public static bool isAttacking = false;

    private float speed;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        navAgent = GetComponent<NavMeshAgent>();
        speed = navAgent.speed;
        StartCoroutine(Think());
    }

    private void TakeDamageUpdate()
    {
        if (PistolCast.hitTarget)
        {
            isTakingDamage = true;
            staggerSteps.Play();
            aiState = AIState.takingDamage;
        }
    }

    private void PlayerStatusUpdate()
    {
        if (Health.playerDead)
        {
            aiState = AIState.idle;
        }
    }

    private IEnumerator TakeDamageAnimation()
    {
        yield return new WaitForSeconds(.001f);
        animator.SetInteger("TakeDamageIndex", Random.Range(0, 2));
        animator.SetTrigger("TakeDamage");
    }

    private IEnumerator AttackAnimation()
    {
        yield return new WaitForSeconds(.001f);
        animator.SetInteger("AttackIndex", Random.Range(0, 2));
        animator.SetTrigger("Attack");
    }

    IEnumerator Think()
    {
        while (true)
        {
            switch (aiState)
            {
                case AIState.idle:
                    float dist = Vector3.Distance(target.transform.position, transform.position);
                    if (!Health.playerDead)
                    {
                        if (dist < chaseThreshold)
                        {
                            aiState = AIState.chasing;
                        }
                        TakeDamageUpdate();
                        navAgent.SetDestination(transform.position);
                    }
                    animator.Play("Idle");
                    break;

                case AIState.betweenAttack:
                    dist = Vector3.Distance(target.transform.position, transform.position);
                    if (!Health.playerDead)
                    {
                        if (dist < chaseThreshold)
                        {
                            aiState = AIState.chasing;
                        }
                        TakeDamageUpdate();
                        navAgent.SetDestination(transform.position);
                        navAgent.transform.LookAt(target.transform.position);
                    }
                    else
                    {
                        aiState = AIState.idle;
                    }
                    animator.Play("BetweenAttack");
                    yield return new WaitForSeconds(1.3f);
                    break;

                case AIState.chasing:
                    dist = Vector3.Distance(target.transform.position, transform.position);
                    if (WeaponMechanics.isAiming)
                    {
                        attackThreshold = 7f;
                    }
                    else
                    {
                        attackThreshold = 5f;
                    }
                    if (dist <= attackThreshold)
                    {
                        yield return new WaitForSeconds(.5f);
                        isAttacking = true;
                        aiState = AIState.attacking;
                    }
                    TakeDamageUpdate();
                    navAgent.speed = speed;
                    navAgent.SetDestination(target.transform.position);
                    animator.Play("Walk");
                    break;

                case AIState.attacking:
                    StartCoroutine(AttackAnimation());
                    TakeDamageUpdate();
                    PlayerStatusUpdate();
                    navAgent.speed = speed;
                    navAgent.SetDestination(transform.position);
                    yield return new WaitForSeconds(1.2f);
                    isAttacking = false;
                    aiState = AIState.betweenAttack;
                    break;

                case AIState.takingDamage:
                    dist = Vector3.Distance(target.transform.position, transform.position);
                    if (!PistolCast.hitTarget)
                    {
                        if (dist > attackThreshold)
                        {
                            isTakingDamage = false;
                            staggerSteps.Stop();
                            aiState = AIState.chasing;
                        }
                        if (dist <= attackThreshold)
                        {
                            yield return new WaitForSeconds(.5f);
                            isAttacking = true;
                            isTakingDamage = false;
                            staggerSteps.Stop();
                           /* currentWhoosh = whooshSounds[Random.Range(0, whooshSounds.Count)];
                            whooshSound.clip = currentWhoosh;
                            whooshSound.Play();*/
                            aiState = AIState.attacking;
                        }
                    }
                    StartCoroutine(TakeDamageAnimation());
                    navAgent.speed = 1.3f;
                    navAgent.SetDestination(target.transform.position);
                    break;

                default:
                    break;
            }
            yield return new WaitForSeconds(0.001f);
        }
    }
}
