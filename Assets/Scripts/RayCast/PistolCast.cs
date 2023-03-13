using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolCast : MonoBehaviour
{
    public LayerMask layerMask;

    public float range = 100f;

    public static bool onTarget = false;
    public static bool hitTarget = false;

    private void Update()
    {

        if (WeaponMechanics.isAiming && !PlayerKnockback.isGettingHit)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitinfo, range, layerMask))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance, Color.red);
                onTarget = true;
            }

            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 20f, Color.blue);
                onTarget = false;
                hitTarget = false;
            }
        }
    }
}
