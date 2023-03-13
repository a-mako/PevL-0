using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCam : MonoBehaviour
{
    public Camera camToSwitch2;
    public Camera[] cams;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            for (int i=0; i < cams.Length; i++)
            {
                if (cams[i].isActiveAndEnabled) {
                    cams[i].gameObject.SetActive(false);
                }
            }
            camToSwitch2.gameObject.SetActive(true);
        }
    }
}
