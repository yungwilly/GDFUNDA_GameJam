using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelController : MonoBehaviour
{
    [SerializeField] PlayerController PController;
    [SerializeField] TimerController TController;
    [SerializeField] GameObject FPSCamera;
    [SerializeField] Text timerText;
    bool levelFinished;
    // Start is called before the first frame update
    void Start()
    {
        levelFinished = false;
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

    public void endLevel()
    {
        levelFinished = true;
    }

    public void beginLevel()
    {
        Debug.Log("test");
        TController.BeginTimer();
        FPSCamera.SetActive(true);
    }
}
