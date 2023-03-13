using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHurtSounds : MonoBehaviour
{
    public List<AudioClip> hurtSounds;
    public AudioClip current;
    public AudioSource audioSource;
    public AudioSource playerDeathSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    
    void Update()
    {
        if (Health.playerDead)
        {
            StartCoroutine(PlayDeathSound());
        }
        else if (PlayerKnockback.isGettingHit)
        {
            StartCoroutine(PlayHurtSound());
        }
    }

    IEnumerator PlayHurtSound()
    {
        if (audioSource.enabled)
        {
            current = hurtSounds[Random.Range(0, hurtSounds.Count)];
            audioSource.clip = current;
            audioSource.Play();
            yield return new WaitForSeconds(.001f);
        }
    }

    IEnumerator PlayDeathSound()
    {
        audioSource.enabled = false;
        playerDeathSound.enabled = true;
        yield return new WaitForSeconds(.001f);
    }
}
