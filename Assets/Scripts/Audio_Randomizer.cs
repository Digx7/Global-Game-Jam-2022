using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audio_Randomizer : MonoBehaviour
{
    [SerializeField] private List<AudioClip> audioClips;
    [SerializeField] private AudioSource audioSource;

    public void Play (){
      audioSource.clip = audioClips[Random.Range(0, audioClips.Count)];
      audioSource.Play();
    }
}
