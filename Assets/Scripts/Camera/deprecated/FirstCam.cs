using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstCam : MonoBehaviour
{

    public GameObject CameraForward;
    public GameObject CameraBackward;

    public float tpDistance;

    public Camera[] cams;

    private GameObject currentCam;

    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            for (int i = 0; i < cams.Length; i++)
            {
                if (cams[i].isActiveAndEnabled)
                {
                    currentCam = cams[i].gameObject;
                }
                cams[i].gameObject.SetActive(false);
            }

            if (currentCam == CameraBackward)
            {
                CameraForward.SetActive(true);
                CameraBackward.SetActive(false);
                currentCam = CameraForward;
                CameraForward = CameraBackward;
                CameraBackward = currentCam;
            }
            if (currentCam == CameraForward)
            {
                CameraBackward.SetActive(true);
                CameraForward.SetActive(false);
                currentCam = CameraBackward;
                CameraBackward = CameraForward;
                CameraForward = currentCam;
            }

            else if (TankControls.isBackingUp)
            {
                other.transform.position += other.transform.forward * -tpDistance;
            }
            else if (TankControls.isRunning)
            {
                other.transform.position += other.transform.forward * tpDistance;
            }
            else
            {
                other.transform.position += other.transform.forward * tpDistance;
            }
        }
    }
}
