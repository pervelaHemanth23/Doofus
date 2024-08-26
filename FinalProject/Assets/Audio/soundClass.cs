using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class soundClass
{
    public string name;

    public AudioClip clip;

    [Range(0f, 100f)]
    public float volume;
    public float pitch;

    public AudioSource source;
}
