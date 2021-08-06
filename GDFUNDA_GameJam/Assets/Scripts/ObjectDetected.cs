using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectDetected : MonoBehaviour
{
    public GameObject Panel;
    public ObjectiveRandomizer randomizer;
    public Text message;

    private IEnumerator OnCollisionEnter(Collision col)
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
            message.text = "You've found " + col.gameObject.name;
            int index = 0;
            for(int i = 0; i < 4; i++)
            {
                if(col.gameObject.name.Equals(randomizer.texts[i].text))
                {
                    index = i;
                }
            }
            randomizer.texts[index].text = randomizer.texts[index].text + " (Done!)";
            Destroy(col.gameObject);
            yield return new WaitForSeconds(1);
            Panel.SetActive(false);
        }else
        {
            if (Panel != null)
            {
                Panel.SetActive(true);
            }
            message.text = col.gameObject.name + " is not part of the list";
        }
    }
}
