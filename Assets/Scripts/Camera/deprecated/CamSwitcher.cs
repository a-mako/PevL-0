using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CamSwitcher : MonoBehaviour
{
    public Transform Player;
    public CinemachineVirtualCamera activeCam;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            activeCam.Priority = 1;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            activeCam.Priority = 0;
        }
    }
}
