using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayAudioRandomPitch : MonoBehaviour
{
    public float pitchMin = 1f;
    public float pitchMax = 1.2f;
    public AudioSource thisAudioSource;
    public AudioClip audioClipToPlay;
    public void PlayRandomPitch()
    {
        thisAudioSource.clip = audioClipToPlay;
        thisAudioSource.pitch = Random.Range(pitchMin, pitchMax);
        thisAudioSource.Play();
    }
}
