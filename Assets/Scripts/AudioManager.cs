using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Ins { get; private set; }

    #region Audio dump

    [field: Header("Music")] // Add music below
    [field: SerializeField] public AudioClip GameplayAmbienceLoop { get; }

    [field: Header("SFX")] // Add sfx below
    [field: SerializeField] public AudioClip BoneBreaking { get; }
    [field: SerializeField] public AudioClip CatStab { get; }
    [field: SerializeField] public AudioClip GlassShatter { get; }
    [field: SerializeField] public AudioClip HammerHitCat { get; }
    [field: SerializeField] public AudioClip HeartbeatLoopFaster { get; }
    [field: SerializeField] public AudioClip HeartbeatLoop { get; }

    [Header("Audio players")]
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource sfxPlayer;

    #endregion

    private void Awake() {
        if(Ins == null) {
            Ins = this;
        } else if(Ins != this) {
            Destroy(this.gameObject);
            return;
        }
    }

    public void PlayMusicOnce(AudioClip clip) {
        musicPlayer.Stop();
        musicPlayer.loop = false;
        musicPlayer.PlayOneShot(clip);
    }

    public void PlayMusicLoop(AudioClip clip) {
        musicPlayer.Stop();
        musicPlayer.loop = true;
        musicPlayer.clip = clip;
        musicPlayer.Play();
    }

    public void PlaySFXOnce(AudioClip clip) {
        sfxPlayer.Stop();
        sfxPlayer.loop = false;
        sfxPlayer.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip) {
        sfxPlayer.Stop();
        sfxPlayer.loop = true;
        sfxPlayer.clip = clip;
        sfxPlayer.Play();
    }

    public void StopMusic() {
        musicPlayer.Stop();
    }

    public void StopSFX() {
        sfxPlayer.Stop();
    }
}