using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueBox : MonoBehaviour
{
    public UnityEvent faded;
    public void OnFade()
    {
        faded?.Invoke();
    }
}
