using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    //[SerializeField] public GameObject playerTrigger;
    [SerializeField] public TimerController timeController;
    // Start is called before the first frame update
    void Start()
    {
        timeController.BeginTimer();
        Debug.Log("Start timer");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter()
    {
        timeController.EndTimer();
        Debug.Log("Tapos na");
    }
}
