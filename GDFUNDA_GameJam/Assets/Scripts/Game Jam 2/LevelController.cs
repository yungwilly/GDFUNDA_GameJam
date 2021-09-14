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
    [SerializeField] GameObject timerText;
    [SerializeField] NPCConversation endConvoManager;
    [SerializeField] GameObject blackoutSquare;
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
        timerText.SetActive(false);
        blackout();
    }

    public void beginLevel()
    {
        Debug.Log("test");
        //blackin();
        TController.BeginTimer();
        FPSCamera.SetActive(true);
        timerText.SetActive(true);
        unlockPlayerMovement();
    }

    public void blackin()
    {
        StartCoroutine(FadeBlackOutSquare(false));
    }

    public void blackout()
    {
        StartCoroutine(FadeBlackOutSquare());
    }

    public IEnumerator FadeBlackOutSquare(bool fadeToBlack = true, int fadeSpeed = 2)
    {
        Color objectColor = blackoutSquare.GetComponent<Image>().color;
        float fadeAmount;

        if(fadeToBlack)
        {
            Debug.Log("blackout");
            while(blackoutSquare.GetComponent<Image>().color.a<255)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else 
        {
            while(blackoutSquare.GetComponent<Image>().color.a>0)
            {
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
