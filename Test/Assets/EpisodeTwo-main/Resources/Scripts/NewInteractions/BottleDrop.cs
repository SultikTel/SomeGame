
using UnityEngine;

public class BottleDrop : MonoBehaviour
{
    [SerializeField] private SoundManager soundManager;
    [SerializeField] private Pressable bottle;
    [SerializeField] private Animator animator;
    private const string TRIGGER_NAME = "Fall";

    private bool onFloor;
    private void Start()
    {
        bottle.OnPress.AddListener(playFallAnimation);
    }

    public void playFallAnimation(Pressable pressable)
    {
        if (onFloor==false) {
            animator.SetTrigger(TRIGGER_NAME);
            onFloor = true;
        }
        else
        {
            bottle.OnPress.RemoveListener(playFallAnimation);
        }
    }

    public void BottleFalledOnGround(Pressable bottle)
    {
        soundManager.Play("BottleFall");
    }

    public void BottleStartedRolling()
    {
        soundManager.Play("BottleRoll");
    }


}
