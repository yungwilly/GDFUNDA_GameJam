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
    // Start is called before the first frame update
    void Start()
    {
        
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

    }

    public void beginLevel()
    {
        Debug.Log("test");
        TController.BeginTimer();
        FPSCamera.SetActive(true);
    }
}
