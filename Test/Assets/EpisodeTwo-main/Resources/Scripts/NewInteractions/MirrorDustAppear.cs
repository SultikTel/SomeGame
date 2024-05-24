using UnityEngine;


public class MirrorDustAppear : MonoBehaviour
{
    [SerializeField] private Pressable mirror;
    [SerializeField] private SpriteRenderer mirrorDust;
    // Start is called before the first frame update
    void Start()
    {
        mirrorDust.enabled = false;
        mirror.OnPress.AddListener(DustAppear);
        
    } 

    public void DustAppear(Pressable pressable)
    {
        mirrorDust.enabled = true;

    }
}
