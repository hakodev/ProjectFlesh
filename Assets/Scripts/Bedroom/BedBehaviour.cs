using System.Threading.Tasks;
using UnityEngine;

public class BedBehaviour : MonoBehaviour
{
    [SerializeField] private Sprite bedEmpty;
    [SerializeField] private Sprite bedKid;
    private SpriteRenderer spriteRenderer;

    //TODO: Change bed sprite depending on whether the player is sleeping or not

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void GetUp()
    {
        spriteRenderer.sprite = bedEmpty;
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
        else if (QuestSystem.instance.AllQuestsCompleted())
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
