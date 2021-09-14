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
    [SerializeField] NPCConversation startConvoManager;
    [SerializeField] NPCConversation endConvoManager;
    [SerializeField] GameObject blackoutSquare;
    [SerializeField] GameObject player;
    [SerializeField] GameObject endScreen;
    [SerializeField] GameObject powerups;
    private bool powerupsChildren;
    private bool quickRestartflag = false;
    private bool storyRestartflag = false;
    private Vector3 spawnPoint = new Vector3((float)-27.87, 0, (float)-36.35);
    // Start is called before the first frame update
    void Start()
    {
        ConversationManager.Instance.StartConversation(startConvoManager);
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
        if (quickRestartflag == true)
        {
            showEndScreen();
        }
        else
        {
            ConversationManager.Instance.StartConversation(endConvoManager);
            lockPlayerMovement();
            timerText.SetActive(false);
            blackout();
        }
        //showEndScreen();
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

    public void quickRestart()
    {
        quickRestartflag = true;
        storyRestartflag = false;
        levelReset();
        beginLevel();
    }

    public void storyRestart()
    {
        quickRestartflag = false;
        storyRestartflag = true;
        levelReset();
        ConversationManager.Instance.StartConversation(startConvoManager);
        lockPlayerMovement();
        FPSCamera.SetActive(false);
    }

    public void levelReset()
    {
        Debug.Log(powerups.transform.childCount);
        for (int i = 0; i < powerups.transform.childCount; ++i)
        {
            powerups.transform.GetChild(i).gameObject.SetActive(true); // or false
        }
        returnToSpawn();
        endScreen.SetActive(false);

    }

    public void returnToSpawn()
    {
        player.transform.position = spawnPoint;
    }

    public void bringPlayerToJail()
    {
        player.transform.position = new Vector3(114, 0, 161);
        blackin();
    }

    public void showEndScreen()
    {
        //blackout();
        endScreen.SetActive(true);
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
            while(blackoutSquare.GetComponent<Image>().color.a<1)
            {
                fadeAmount = objectColor.a + (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
        else
        {
            Debug.Log("blackin");
            while (blackoutSquare.GetComponent<Image>().color.a>0)
            {
                Debug.Log(blackoutSquare.GetComponent<Image>().color.a);
                fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

                objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
                blackoutSquare.GetComponent<Image>().color = objectColor;
                yield return null;
            }
        }
    }
}
