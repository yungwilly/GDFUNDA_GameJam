using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DialogueEditor;

public class LevelController : MonoBehaviour
{
    [SerializeField] PlayerController PController;
    [SerializeField] TimerController TController;
    [SerializeField] GameObject FPSCamera;
    [SerializeField] Text timerText;
    [SerializeField] NPCConversation endConvoManager;
    bool levelFinished;
    // Start is called before the first frame update
    void Start()
    {
        levelFinished = false;
        lockPlayerMovement();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Finish")
        {
            TController.EndTimer();
            Debug.Log("collided with goal");
            endLevel();
        }
    }

    public void lockPlayerMovement()
    {
        PController.GetComponent<FirstPersonMovement>().setSpeed(0);
    }

    public void unlockPlayerMovement()
    {
        PController.GetComponent<FirstPersonMovement>().setSpeed(10);
    }

    public void endLevel()
    {
        levelFinished = true;
        ConversationManager.Instance.StartConversation(endConvoManager);
        lockPlayerMovement();
    }

    public void beginLevel()
    {
        Debug.Log("test");
        TController.BeginTimer();
        FPSCamera.SetActive(true);
        unlockPlayerMovement();
    }
}
