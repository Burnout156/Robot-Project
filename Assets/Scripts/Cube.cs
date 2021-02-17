using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    public GameObject particle;

    // Start is called before the first frame update
    void Start()
    {
        particle = GetComponentInChildren<ParticleSystem>().gameObject;
        particle.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Floor"))
        {
            particle.SetActive(true);
        }
    }
}
