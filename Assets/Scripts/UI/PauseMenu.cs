using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public static bool gamePaused = false;

    public GameObject pauseScreen;

    public AudioSource[] gameSounds;
    public AudioSource pauseGameSound;
    public AudioSource unpauseGameSound;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !InventoryControl.isOpen)
        {
            if (!gamePaused)
            {
                Time.timeScale = 0;
                gamePaused = true;
                pauseGameSound.Play();
                foreach (AudioSource sound in gameSounds) {
                    sound.Pause();
                }
                pauseScreen.SetActive(true);
            }
            else
            {
                pauseScreen.SetActive(false);
                unpauseGameSound.Play();
                foreach (AudioSource sound in gameSounds) {
                    sound.UnPause();
                }
                gamePaused = false;
                Time.timeScale = 1;
            }
        }
    }
}
