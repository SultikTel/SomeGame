using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    [SerializeField] private DialogueManager dialogueManager;
    [SerializeField] private Pressable[] pressables;

    private void Start()
    {
        foreach(Pressable pressable in pressables)
        {
            pressable.OnPress.AddListener(TriggerDialogue);
        }
    }

    private void OnDisable()
    {
        foreach (Pressable pressable in pressables)
        {
            pressable.OnPress.RemoveListener(TriggerDialogue);
        }
    }
    public void TriggerDialogue(Pressable pressable)
    {
        
        dialogueManager.StartDialogue(pressable.GetDialogue(), pressable.GetSound(), pressable.GetImage());
    }
}
