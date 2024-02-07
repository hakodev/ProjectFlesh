using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class MainMenu : MonoBehaviour {
    [SerializeField] private Image blackScreen;
    [SerializeField] private Button gameOverTryAgainButton;
    [SerializeField] private Button gameOverQuitButton;
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

    public void BackToMenu() {
        gameOverQuitButton.enabled = false;
        blackScreen.DOFade(1f, 1.5f);
        menuMusic.DOFade(0f, 1.5f).OnComplete(() => SceneManager.LoadScene(0));
    }

    public void QuitGame() {
        gameOverTryAgainButton.enabled = false;
        blackScreen.DOFade(1f, 1.5f);
        menuMusic.DOFade(0f, 1.5f).OnComplete(() => Application.Quit());
    }
}
