using UnityEngine;

public class PlayerVisual : MonoBehaviour
{
    [SerializeField] Animator animator;
    [SerializeField] Player player;

    private const string IS_WALKING = "IsWalking";
    // Start is called before the first frame update


    private void Awake()
    {
        player.changedRunningStatus += ChangedRunStatus;
        player.lookedLeft += LookLeft;
    }
    public void ChangedRunStatus(bool isRunning)
    {
        animator.SetBool(IS_WALKING, isRunning);
    }

    public void LookLeft(bool isLookingLeft)
    {
        if (isLookingLeft == false)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

}
