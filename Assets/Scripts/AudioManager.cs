using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    private static AudioManager _instance;
    private void Awake()
    {
        if (_instance == null)
            _instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
        
        DontDestroyOnLoad(gameObject);
        
        foreach (var s in sounds)
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
        Play("Main Theme");
    }

    private void Update()
    {
        
    }

    private void Play(string soundName)
    {
        var s = Array.Find(sounds, sound => sound.name == soundName);

        if (s == null)
        {
            Debug.Log("Sound with name" + soundName + "can't be found.");    
            return;
        }
        
        s.source.Play();
    }
}