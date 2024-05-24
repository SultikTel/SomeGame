using UnityEngine.Audio;
using System;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private Sound[] audioList;
    [SerializeField] private AudioSource audioSource;


    public void Play(string name)
    {
        Sound s = Array.Find(audioList, gunAudio => gunAudio.name == name);
        if (s == null)
        {
            return;
        }
        audioSource.PlayOneShot(s.clip);
    }
}
