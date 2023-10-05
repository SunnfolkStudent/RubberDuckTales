using UnityEngine.Audio;
using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class AudioManager : MonoBehaviour
{
    [Header("---------- Audio Source ----------")]
    [SerializeField] private AudioSource musicSource;
    [SerializeField] private AudioSource _randomSqueaks;

    [Header("---------- Audio Clip ----------")]
    public AudioClip Sandbox;
    public AudioClip Park;
    public AudioClip Street;
    public AudioClip Apartment;
    public AudioClip Bathroom;
    public AudioClip otherClip;

    IEnumerator Start()
    {
        
        
        musicSource.clip = Sandbox;
        musicSource.Play();
        yield return new WaitForSeconds(10f);
        musicSource.clip = otherClip;
        musicSource.Play();
    }


    /* public bool PlayNext;
    {
        if () 
        {
            
        }
    } */
    public void PlaySqueaks(AudioClip clip)
    {
        _randomSqueaks.PlayOneShot(_randomSqueaks.clip);
    }

    /* public AudioSource[] Squeaks;

    public static AudioManager instance;

    // Start is called before the first frame update
    void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);

        foreach (Sound s in Squeaks)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    private void Start()
    {
        Play("Song 1 - Sandbox");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(Squeaks, sound => sound.name == name);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "Not Found!");
            return;
        }

        s.source.Play();
    }

    public void StopPlaying(string sound)
    {
        Sound s = Array.Find(Sound, item => item.name == sound);
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + " not found!");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volume / 2f, s.volume / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitch / 2f, s.pitch / 2f));

        s.source.Stop();

    }*/
}