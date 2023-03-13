using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomZombieMoans : MonoBehaviour
{
    public List<AudioClip> zombieMoans;
    public AudioClip current;
    public AudioSource audioSource;
    public float minWaitBetweenPlays = 1f;
    public float maxWaitBetweenPlays = 5f;
    public float waitTimeCountdown = -1f;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        if (!audioSource.isPlaying)
        {
            if (waitTimeCountdown < 0f)
            {
                current = zombieMoans[Random.Range(0, zombieMoans.Count)];
                audioSource.clip = current;
                audioSource.Play();
                waitTimeCountdown = Random.Range(minWaitBetweenPlays, maxWaitBetweenPlays);
            }
            else
            {
                waitTimeCountdown -= Time.deltaTime;
            }
        }
    }
}