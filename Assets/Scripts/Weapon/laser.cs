using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laser : MonoBehaviour
{
    public LineRenderer sight;

    public LayerMask enemyLayerMask;
    public LayerMask objectLayerMask;

    public float range = 100f;

    void Start()
    {
        sight = GetComponent<LineRenderer>();
        sight.SetColors(Color.clear, Color.clear);
    }

    // Update is called once per frame
    void Update()
    {
        if (WeaponMechanics.isAiming)
        {
            Ray ray = new Ray(this.transform.position, this.transform.forward);
            if (Physics.Raycast(ray, out RaycastHit hitinfo, range, enemyLayerMask))
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hitinfo.distance);
                sight.SetPosition(1, new Vector3(0, 0, hitinfo.distance));
                sight.SetColors(Color.red, Color.red);
            }
            else if (Physics.Raycast(ray, out RaycastHit objHitInfo, range, objectLayerMask))
            {
                sight.SetPosition(1, new Vector3(0, 0, objHitInfo.distance));
                sight.SetColors(Color.green, Color.green);
            }

            /*else
            {
                //Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * range);
                sight.SetPosition(1, new Vector3(0, 0, range));
                sight.SetColors(Color.blue, Color.clear);
            }*/
        }
        else
        {
            sight.SetColors(Color.clear, Color.clear);
        }
    }
}
