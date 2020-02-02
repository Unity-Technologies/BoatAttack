using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class BoatAudioCollision : MonoBehaviour
{
    public AudioClip[] audioClips;

    public float variability = .5f;

    private AudioSource audioSource;
    
    private void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void OnCollisionEnter(Collision col)
    {
        if(col.gameObject.layer == gameObject.layer)
        {
            int c = Random.Range(0, audioClips.Length-1);
            AudioClip clip = audioClips[c];
            audioSource.clip = clip;
            audioSource.pitch = 1 + Random.Range(-variability, variability);
            audioSource.Play();
        }
    }

}
