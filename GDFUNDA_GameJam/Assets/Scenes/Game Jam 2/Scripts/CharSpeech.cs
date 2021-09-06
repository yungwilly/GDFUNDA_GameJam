using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DialogueEditor;

public class CharSpeech : MonoBehaviour
{
    public NPCConversation myConversation;
    void OnGUI()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Start()
    {
        ConversationManager.Instance.StartConversation(myConversation);
    }


}
