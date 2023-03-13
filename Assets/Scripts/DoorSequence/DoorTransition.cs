using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorTransition : MonoBehaviour
{
    public string sceneToSwitchTo;
    public string doorScene;

    public GameObject mainCamera;
    public GameObject door;

    public string moveThrough;

    public AudioSource doorOpen;
    public AudioSource doorClose;

    private void Start()
    {
        sceneToSwitchTo = DoorController.nextSequence;
        StartCoroutine(Sequence());
    }

    IEnumerator Sequence()
    {
        yield return new WaitForSeconds(1.75f);
        doorOpen.Play();
        door.GetComponent<Animation>().Play("DoorOpen");
        yield return new WaitForSeconds(1.25f);
        mainCamera.GetComponent<Animation>().Play(moveThrough);
        yield return new WaitForSeconds(1.55f);
        doorClose.Play();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(sceneToSwitchTo);
    }
}
