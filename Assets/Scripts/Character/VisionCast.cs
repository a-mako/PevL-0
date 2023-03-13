using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisionCast : MonoBehaviour
{
    public static bool facingZombie;

    GameObject[] doors;
    GameObject[] enemies;

    void Start()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
        enemies = GameObject.FindGameObjectsWithTag("Zombie");
    }
    void Update()
    {
        foreach (GameObject door in doors) {
            float distance = Vector3.Distance(door.transform.position, this.transform.position);
            float dot = Vector3.Dot(transform.forward, (door.transform.position - transform.position).normalized);
            if (dot > 0.7f)
            {
                if (distance < 4f)
                {
                    Debug.DrawRay(transform.position, door.transform.position, Color.magenta);
                    Debug.Log("Facing Object");
                }
            }
        }

        foreach (GameObject enemy in enemies)
        {
            float distance = Vector3.Distance(enemy.transform.position, this.transform.position);
            float dot = Vector3.Dot(transform.forward, (enemy.transform.position - transform.position).normalized);
            if (dot > 0.7f)
            {
                if (distance < 8f)
                {
                    Debug.DrawRay(transform.position, enemy.transform.position, Color.yellow);
                    Debug.Log("Facing Zombie");
                    facingZombie = true;
                }
            }
            else
            {
                facingZombie = false;
            }
        }
    }
}
