using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject particle;
    public Platform platform;
    public bool isPlatform;

    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>().gameObject;
        particle.SetActive(false);
        platform = GameObject.FindObjectOfType<Platform>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //particle.SetActive(true);
            //Destroy(GetComponent<Rigidbody>());
        }

        else if(collision.gameObject.tag.Equals("Platform"))
        {
            isPlatform = true;
            particle.SetActive(true);
            particle.GetComponent<ParticleSystem>().Simulate(0.0f, true, true);
            particle.GetComponent<ParticleSystem>().Play();
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            //Destroy(GetComponent<Rigidbody>());           
            platform.InsertBlock(this.gameObject);
            Debug.Log(gameObject.name + " is colliding platform");
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Platform") && !isPlatform)
        {
            platform.RemoveBlock(this.gameObject);
            GetComponent<Rigidbody>().useGravity = false;
            GetComponent<Rigidbody>().isKinematic = true;
            Debug.Log(gameObject.name + " not colliding platform");
        }
    }
}
