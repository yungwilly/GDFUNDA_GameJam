using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    bool panelActive = false;
    //[SerializeField] public GameObject playerTrigger;
    //[SerializeField] public TimerController timeController;
    // Start is called before the first frame update
    void Start()
    {
        //timeController.BeginTimer();
        //Debug.Log("Start timer");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("tab"))
        {
            if (panelActive)
            {
                panel.SetActive(false);
                panelActive = false;
            }
            else
            {
                panel.SetActive(true);
                panelActive = true;
            }
        }
    }

    private void OnTriggerEnter()
    {
        //timeController.EndTimer();
        //Debug.Log("Tapos na");
    }
}
