using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable]

public class Dialogue
{
    [System.Serializable]
    public class Sentence
    {
        [TextArea]
        public string name;
        [TextArea]
        public string text;
    }

    [SerializeField]
    public Sentence[] sentences;

    public UnityEvent OnDialogueStart;
    public UnityEvent OnDialogueEnd;
}
