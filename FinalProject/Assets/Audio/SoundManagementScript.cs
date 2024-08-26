using UnityEngine.Audio;
using UnityEngine;
using System;

public class SoundManagementScript : MonoBehaviour
{
    public soundClass[] sounds;

    private void Awake()
    {
        foreach(soundClass s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
        }
    }

    public void playClick(string name)
    {
        soundClass s = Array.Find(sounds, soundClass => soundClass.name == name);
        s.source.Play();
    }
}
