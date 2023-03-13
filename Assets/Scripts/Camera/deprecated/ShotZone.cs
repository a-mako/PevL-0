using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotZone : MonoBehaviour
{
    public Shot targetShot;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            targetShot.CutToShot();
        }
    }
}
