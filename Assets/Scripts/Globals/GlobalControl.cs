using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalControl : MonoBehaviour
{
    public GameObject fadeIn;

    void Start()
    {
        /*Cursor.visible = false;*/
        fadeIn.SetActive(true);
        Debug.Log("fadeIn: " + fadeIn.activeSelf);
        fadeIn.GetComponent<Animator>().Play("FadeIn");
    }


    void Update()
    {
        
    }
}
