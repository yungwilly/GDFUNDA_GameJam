using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectDetected : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "Book_25")
        {
            Debug.Log("Item is Book_25");
        }
        else if (col.gameObject.name == "Book_29")
        {

        }
    }
}
