using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Image blackScreen;
    private AudioSource menuMusic;

    private void Awake() {
        menuMusic = GetComponent<AudioSource>();
    }

    private void Start() {
        blackScreen.DOFade(0f, 0.75f);

        menuMusic.loop = true;
        menuMusic.PlayScheduled(1f);
    }

    public void StartGame() {
        blackScreen.DOFade(1f, 1.5f);
        menuMusic.DOFade(0f, 1.5f).OnComplete(() => SceneManager.LoadScene(1));
    }
}
