using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrongObjectDetected : MonoBehaviour
{
    public GameObject Panel;

    public void OpenPanel()
    {
        if (Panel != null)
        {
            Panel.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name != "SpicyRecipesBook")
        {
            if (Panel != null)
            {
                Panel.SetActive(true);
            }
        }
    }
}
