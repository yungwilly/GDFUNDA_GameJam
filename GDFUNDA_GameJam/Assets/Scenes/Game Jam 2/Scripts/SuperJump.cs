using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperJump : MonoBehaviour
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
        player.GetComponent<Jump>().setJumpStrength(10);
        //player.transform.Translate(Vector3.forward * multiplier * Time.deltaTime);

        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Collider>().enabled = false;

        yield return new WaitForSeconds(duration);

        //player.transform.Translate(Vector3.forward / multiplier * Time.deltaTime);
        player.GetComponent<Jump>().setJumpStrength(2);

        Destroy(gameObject);

    }
}

