using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClipManager : MonoBehaviour
{
    public List<AudioClip> audioClips = new List<AudioClip>();
    public static SoundClipManager instance;
    public AudioSource audioSource;

    public int levelClipAudio;
    private void Awake()
    {
        instance = this;
    }

    private void Start()
    {
        PlaySound(2);
        levelClipAudio = 2;
    }

    public void PlaySound(int id)
    {
        audioSource.PlayOneShot(audioClips[id]);
        
    }

    public void OnSoundPlayedByInteraction(int id)
    {
        PlaySound(id);
        if (levelClipAudio == id)
        {

        }
    }

    public void WinGame()
    {

    }


}
