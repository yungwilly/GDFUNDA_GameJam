using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperSpeedPowerup : MonoBehaviour
{
    public float multiplier = 5.0f;
    public float duration = 4.0f;
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(Pickup(other));
        }
    }

    IEnumerator Pickup(Collider player)
    {
        player.transform.Translate(Vector3.forward * multiplier * Time.deltaTime);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        player.transform.Translate(Vector3.forward / multiplier * Time.deltaTime);

        Destroy(gameObject);

    }
}
