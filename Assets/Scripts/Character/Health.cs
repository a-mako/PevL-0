using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public static bool playerDead = false;

    public float startingHealth = 100f;
    public float healthPoints
    {
        get
        {
            return _healthPoints;
        }
        set
        {
            _healthPoints = Mathf.Clamp(value, 0f, startingHealth);

            if (_healthPoints <= 0f)
            {
                if (gameObject.CompareTag("Player"))
                {
                    playerDead = true;
                    gameObject.GetComponent<Animator>().SetTrigger("Death");
                }
            }
        }
    }

    [SerializeField]
    private float _healthPoints = 100f;

    void Start()
    {
        healthPoints = startingHealth;
    }
}
