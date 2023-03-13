using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    public LayerMask player;
    public static bool inSight;
    void Update()
    {
        Ray ray = new Ray(this.transform.position, this.transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hitinfo, 20f, player))
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
            inSight = true;
        }

        else
        {
            Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.green);
            inSight = false;
        }
    }
}
