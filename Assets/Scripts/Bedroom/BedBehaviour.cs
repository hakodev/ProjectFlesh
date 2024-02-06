using System.Threading.Tasks;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class BedBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite bedEmpty;
    [SerializeField] private Sprite bedKid;
    private SpriteRenderer spriteRenderer;
    public TextMeshProUGUI InteractText;
    //TODO: Change bed sprite depending on whether the player is sleeping or not

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetUp()
    {
        spriteRenderer.sprite = bedEmpty;
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            InteractText.DOFade(1f, 0.25f);
        }
    }

    private void OnTriggerExit2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player"))
        {
            InteractText.DOFade(0f, 0.25f);
        }
    }

    private void OnTriggerStay2D(Collider2D otherCollider)
    {
        if (otherCollider.CompareTag("Player") && Input.GetKey(KeyCode.E))
        {
            Sleep();
        }
    }
    public async void Sleep()
    {

        bool willSleep=false;

        if (HorrorSystem.instance.horrorActive)
        {
            HorrorSystem.instance.EndHorrorSequence();
            spriteRenderer.sprite = bedKid;
            willSleep = true;

        }
        else if (QuestSystem.instance.ISAllQuestsCompleted())
        {
            spriteRenderer.sprite = bedKid;
            willSleep = true;

        }

        await Task.Delay(2000);
        if (willSleep)
        {
            GameManager.instance.EndDay();
        }


    }
}
