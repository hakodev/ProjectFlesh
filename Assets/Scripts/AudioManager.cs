using UnityEngine;

public class AudioManager : MonoBehaviour {
    public static AudioManager Ins { get; private set; }

    #region Audio dump

    [field: Header("Music")] // Add music below
    [field: SerializeField] public AudioClip DaytimeMusicLoop { get; private set; }
    [field: SerializeField] public AudioClip MainMenuMusicLoop { get; private set; }
    [field: SerializeField] public AudioClip ChaseMusicLoop { get; private set; }
    [field: SerializeField] public AudioClip GameOverMusicLoop { get; private set; }

    [field: Header("SFX")] // Add sfx below
    [field: SerializeField] public AudioClip HeartbeatLoopFaster { get; private set; }
    [field: SerializeField] public AudioClip HeartbeatLoop { get; private set; }
    [field: SerializeField] public AudioClip MenuClickSFX { get; private set; }
    [field: SerializeField] public AudioClip PlayerLost { get; private set; }
    [field: SerializeField] public AudioClip[] Footsteps { get; private set; }

    [Header("Audio players")]
    [SerializeField] private AudioSource musicPlayer;
    [SerializeField] private AudioSource sfxPlayer;
    [SerializeField] private AudioSource sfxPlayer2;
    [SerializeField] private AudioSource sfxPlayer3;

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

    public void PlaySFXOnce2(AudioClip clip) {
        sfxPlayer2.Stop();
        sfxPlayer2.loop = false;
        sfxPlayer2.PlayOneShot(clip);
    }

    public void PlaySFXOnce3(AudioClip clip) {
        sfxPlayer3.Stop();
        sfxPlayer3.loop = false;
        sfxPlayer3.PlayOneShot(clip);
    }

    public void PlaySFXLoop(AudioClip clip) {
        sfxPlayer.Stop();
        sfxPlayer.loop = true;
        sfxPlayer.clip = clip;
        sfxPlayer.Play();
    }

    public void PlaySFXLoop2(AudioClip clip) {
        sfxPlayer2.Stop();
        sfxPlayer2.loop = true;
        sfxPlayer2.clip = clip;
        sfxPlayer2.Play();
    }

    public void PlaySFXLoop3(AudioClip clip) {
        sfxPlayer3.Stop();
        sfxPlayer3.loop = true;
        sfxPlayer3.clip = clip;
        sfxPlayer3.Play();
    }

    public void StopMusic() {
        musicPlayer.Stop();
    }

    public void StopSFX() {
        sfxPlayer.Stop();
    }
}
