using UnityEngine;
using UnityEngine.Events;


public class Pressable : MonoBehaviour
{
    [SerializeField] private Dialogue dialogue;
    [SerializeField] private AudioClip audioClip;
    [SerializeField] private DialogueTrigger dialogueTrigger;
    [SerializeField] private Sprite image;
   
    private SpriteRenderer outline_image;
    private bool isHighlighted;
    public Color inactive_color;

    public UnityEvent<Pressable> OnPress;
    public UnityEvent OnExit;

    void Start()
    {
        outline_image = GetComponent<SpriteRenderer>();
        outline_image.color = inactive_color;  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && isHighlighted)
        {
            GetKeyDown();
        }
    }

    public void OnMouseEnter() {
        isHighlighted = true;
        outline_image.color = Color.white;
       
    }

    public void OnMouseExit() {
        isHighlighted = false;
        outline_image.color = inactive_color;
        
    }

    private void GetKeyDown() {
        
        OnPress.Invoke(this);
        outline_image.color = inactive_color;
    }

    public Dialogue GetDialogue()
    {
        return dialogue;
    }
    public AudioClip GetSound()
    {
        return audioClip;
    }

    public Sprite GetImage()
    {
        return image;
    }

}
