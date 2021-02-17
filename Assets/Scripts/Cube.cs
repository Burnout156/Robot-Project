using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject particle;

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>().gameObject;
        particle.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor"))
        {
            //particle.SetActive(true);
            Destroy(GetComponent<Rigidbody>());
        }

        else if(collision.gameObject.tag.Equals("Platform"))
        {
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
            particle.GetComponent<ParticleSystem>().Play();
            Destroy(GetComponent<Rigidbody>());
        }
    }
}
