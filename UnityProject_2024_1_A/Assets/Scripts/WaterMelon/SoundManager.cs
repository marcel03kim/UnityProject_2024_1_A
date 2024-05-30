using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

[System.Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [Range(0f, 1f)]
    public float volume = 1.0f;
    
    [Range(0.1f, 3f)]
    public float pitch = 1.0f;
    public bool loop;
    public AudioMixerGroup mixer;

    [HideInInspector]
    public AudioSource source;
}
public class SoundManager : MonoBehaviour
{
    public static SoundManager instance;
    public List<Sound> sounds = new List<Sound>();
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach(Sound sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
            sound.source.outputAudioMixerGroup = sound.mixer;
        }
    }

    public void PlaySound(string name)
    {
        Sound soundToPlay = sounds.Find(sound => sound.name == name);
        if(soundToPlay != null)
        {
            soundToPlay.source.Play();
        }
        else
        {
            Debug.LogWarning("Cannot find" + name + "sound");
        }
    }
}
