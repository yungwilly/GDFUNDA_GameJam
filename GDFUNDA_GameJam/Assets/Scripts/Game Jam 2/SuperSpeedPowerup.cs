using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeedPowerup : MonoBehaviour
{
    public float multiplier = 5.0f;
    public float duration = 4.0f;
    [SerializeField] GameObject player;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        player.GetComponent<FirstPersonMovement>().setSpeed(15);
        player.GetComponent<FirstPersonMovement>().setRunSpeed(25);
        //player.transform.Translate(Vector3.forward * multiplier * Time.deltaTime);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        //player.transform.Translate(Vector3.forward / multiplier * Time.deltaTime);
        player.GetComponent<FirstPersonMovement>().setSpeed(10);
        player.GetComponent<FirstPersonMovement>().setRunSpeed(15);

        gameObject.SetActive(false);

    }
}
