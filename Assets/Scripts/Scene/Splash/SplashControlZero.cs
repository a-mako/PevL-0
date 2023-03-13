using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SplashControlZero : MonoBehaviour
{
    [SerializeField] float waitForSeconds = 15f;
    [SerializeField] int sceneLoadNum = 1;
    void Start()
    {
        StartCoroutine(PlaySplash());
    }

    IEnumerator PlaySplash()
    {
        yield return new WaitForSeconds(waitForSeconds);
        SceneManager.LoadScene(sceneLoadNum);
    }
}
