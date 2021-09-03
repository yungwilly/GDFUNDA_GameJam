using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public float multiplier = 10.0f;
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
        player.transform.position += player.transform.forward * multiplier;
        //player.GetComponent<FirstPersonMovement>().setSpeed(15);
        //player.transform.Translate(Vector3.forward * multiplier * Time.deltaTime);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        //player.transform.Translate(Vector3.forward / multiplier * Time.deltaTime);
        //player.GetComponent<FirstPersonMovement>().setSpeed(5);

        Destroy(gameObject);

    }
}
