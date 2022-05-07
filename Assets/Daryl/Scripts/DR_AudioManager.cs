using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DR_AudioManager : MonoBehaviour
{
    private static DR_AudioManager instance;
    public static DR_AudioManager Instance
    {
        get
        {
            instance = FindObjectOfType<DR_AudioManager>();
            if (instance == null)
            {
                GameObject audioPlayerGameObject = new GameObject("AudioPlayerGameObject");
                instance = audioPlayerGameObject.AddComponent<DR_AudioManager>();
                instance.AudioPlayer = audioPlayerGameObject.AddComponent<AudioSource>();
                instance.AudioPlayer.clip = Resources.Load<AudioClip>("Audio/TADA");
                instance.LevelUpSoundEffect = instance.AudioPlayer.clip;
                DontDestroyOnLoad(audioPlayerGameObject);
            }
            return instance;
        }
    }
    public AudioSource AudioPlayer;

    private AudioClip _levelUpSoundEffect;
    public AudioClip LevelUpSoundEffect
    {
        get { return _levelUpSoundEffect; }
        private set { _levelUpSoundEffect = value; }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }    
        else
        {
            Destroy(gameObject);
        }
    }
}
