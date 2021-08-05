using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetected : MonoBehaviour
{
    public GameObject Panel;
    public ObjectiveRandomizer randomizer;

    private void OnCollisionEnter(Collision col)
    {
        Debug.Log("Item is " + col.gameObject.name);
        Debug.Log(randomizer.objectives[0]);
        if (randomizer.objectives.Contains(col.gameObject))
        {
            Debug.Log("You've found the first item");
            if (Panel != null)
            {
                Panel.SetActive(true);
            }
            Destroy(col.gameObject);
        }
        else
            Debug.Log("Not included in the list");
    }
}
