using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoAim : MonoBehaviour
{
    public Transform enemy;

    public float aimSpeed;

    public static bool autoAim;

    void Update()
    {
        /*if (enemy.gameObject.activeInHierarchy)
        {
            aimSpeed = 10f;
            Vector3 targetDir = enemy.position - this.transform.position;
            targetDir.y = 0;
            float rotateStep = aimSpeed * Time.deltaTime;
            Vector3 newDir = Vector3.RotateTowards(this.transform.forward, targetDir, rotateStep, 0);
            this.transform.rotation = Quaternion.LookRotation(newDir);
        }*/
    }
}
