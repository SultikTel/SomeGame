using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI nameText;
    [SerializeField] private Animator boxAnim;
    [SerializeField] private DialogueBox dialogueBox;
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private Animator imageAnim;
    [SerializeField] private Image image;
    //public Animator startAnim;

    public delegate void DialogueAction();
    private Queue<DialogueAction> dialogue_actions;

    private bool isDialogueBoxBarFaded;

    public void DialogueBoxBarFaded()
    {
        isDialogueBoxBarFaded = true;
    }
    

    private void Start()
    {
        isDialogueBoxBarFaded = true;
        dialogueBox.faded.AddListener(DialogueBoxBarFaded);
        dialogue_actions = new Queue<DialogueAction>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (dialogue_actions.Count != 0)
            {
                NextMessage();
            }
        }
    }

    public void StartDialogue(Dialogue dialogue, AudioClip audioClip,Sprite image)
    {
        if (dialogue_actions.Count == 0 && isDialogueBoxBarFaded == true)
        {
            boxAnim.SetBool("boxOpen", true);
            if (audioClip != null)
            {
                audioSource.PlayOneShot(audioClip);
            }
            if (image != null)
            {
                this.image.sprite = image;
                imageAnim.SetTrigger("Appear");
            }
           

            dialogue.OnDialogueStart.Invoke(); 

            foreach (Dialogue.Sentence sentence in dialogue.sentences)
            {
                dialogue_actions.Enqueue(() => StartCoroutine(TypeSentence(sentence))); 
            }
            dialogue_actions.Enqueue(() => EndDialogue()); 
            dialogue_actions.Enqueue(() => dialogue.OnDialogueEnd.Invoke()); 

            NextMessage();
        }
    }

    IEnumerator TypeSentence(Dialogue.Sentence sentence)
    {
        dialogueText.text = "";
        nameText.text = sentence.name;
        foreach (char letter in sentence.text)
        {
            dialogueText.text += letter;
        }
        yield return null;
    }

    public void NextMessage()
    {
        StopAllCoroutines();
        dialogue_actions.Dequeue().Invoke(); 
    }

    public void EndDialogue()
    {
        while (dialogue_actions.Count != 0)
        {
            NextMessage();
        }
        isDialogueBoxBarFaded = false;
        audioSource.Stop();
        imageAnim.SetTrigger("DisAppear");
        boxAnim.SetBool("boxOpen", false);
    }

    public void AbruptEnding()
    {
        dialogue_actions.Clear();
        boxAnim.SetBool("boxOpen", false);

    }
}