using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class SanityManager : MonoBehaviour
{
    [SerializeField] private PlayerController playerController;
    [SerializeField] private Image blackScreen;

    public float sanity = 100;
    public float threat = 0;

    public Image sanityBar, threatBar;



    public static SanityManager instance;
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;

        }
        else
        {
            Destroy(this);
        }


    }

    private void Start()
    {
        SceneManager.sceneLoaded += Initialize;

       
    }


    public void Initialize(Scene scene, LoadSceneMode mode)
    {
        sanityBar.fillAmount = sanity / 100;
        threatBar.fillAmount = threat / 100;

    }
    public void SanityChange(float amount,bool constant=false)
    {
        sanity += amount;
        sanity = Mathf.Clamp(sanity, 0, 100);

        if(HorrorSystem.instance.horrorActive && sanity < 26) {
            AudioManager.Ins.PlaySFXLoop2(AudioManager.Ins.HeartbeatLoopFaster);
        }

        if (sanity <= 0)
        {
            Die();
        }
        if (constant)
        {
            sanityBar.fillAmount = sanity / 100;
            return;
        }
        sanityBar.DOFillAmount( sanity / 100,0.2f);
    }

    public void ThreatChange(float amount,bool constant = false)
    {
        threat += amount;
        threat = Mathf.Clamp(threat, 0, 100);

        if(HorrorSystem.instance.horrorActive && threat > 74) {
            AudioManager.Ins.PlaySFXLoop2(AudioManager.Ins.HeartbeatLoopFaster);
        }

        if (threat >= 100)
        {
            Die();
        }
        if (constant)
        {
            threatBar.fillAmount = threat / 100;
            return;
        }
        threatBar.DOFillAmount(threat / 100, 0.2f);
    }


    public void Die()
    {
        playerController.HorizontalAxis = 0;
        playerController.enabled = false;
        AudioManager.Ins.StopMusic();
        AudioManager.Ins.PlaySFXOnce3(AudioManager.Ins.PlayerLost);
        blackScreen.DOFade(1f, 4f).OnComplete(() => {
            SceneManager.LoadScene(2);
        });
    }

}
