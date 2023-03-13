using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProximityCheck : MonoBehaviour
{
    public static bool againstWall;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Solid Object") || collision.gameObject.CompareTag("Door"))
        {
            againstWall = true;
            Debug.Log("againstWall: " + againstWall);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Solid Object") || collision.gameObject.CompareTag("Door"))
        {
            againstWall = false;
            Debug.Log("againstWall: " + againstWall);
        }
    }
}