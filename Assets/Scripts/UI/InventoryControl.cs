using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryControl : MonoBehaviour
{
    public GameObject inventoryScreen;
    public GameObject inventoryFade;

    public AudioSource inventoryOpen;
    public AudioSource inventoryClose;

    public static bool isOpen = false;
    public bool canClose = false;

    void Update()
    {
        if (Input.GetButton("IKey") && !isOpen && !canClose && !PauseMenu.gamePaused)
        {
            isOpen = true;
            inventoryOpen.Play();
            inventoryFade.SetActive(true);
            StartCoroutine(InvControl());
        }

        if (Input.GetButton("IKey") && isOpen && canClose && !PauseMenu.gamePaused)
        {
            isOpen = false;
            Time.timeScale = 1;
            Cursor.visible = false;
            inventoryClose.Play();
            inventoryFade.SetActive(true);
            StartCoroutine(InvControl());
        }
    }

    public void ExitButton()
    {
        isOpen = false;
        Time.timeScale = 1;
        Cursor.visible = false;
        inventoryClose.Play();
        inventoryFade.SetActive(true);
        StartCoroutine(InvControl());
    }

    IEnumerator InvControl()
    {
        yield return new WaitForSeconds(0.25f);
        if (isOpen)
        {
            inventoryScreen.SetActive(true);
        }
        if (!isOpen)
        {
            inventoryScreen.SetActive(false);
        }
        yield return new WaitForSeconds(0.25f);
        inventoryFade.SetActive(false);
        
        if (isOpen)
        {
            canClose = true;
            Time.timeScale = 0;
            Cursor.visible = true;
        }
        if (!isOpen)
        {
            canClose = false;
        }
    }
}
