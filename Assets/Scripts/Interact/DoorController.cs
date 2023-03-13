using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    private GameObject player;

    public bool isLocked;

    public string doorTransition;
    public string nextScene;

    public static string nextSequence;
    public static Quaternion playerDir;

    public void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        nextSequence = nextScene;
    }
    public void Open()
    {
        if (isLocked)
        {
            // Do nothing for now
        }

        playerDir = player.GetComponent<Transform>().rotation;
        SceneManager.LoadScene(doorTransition);
    }
}
