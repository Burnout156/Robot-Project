﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public CharacterController characterController;
    public Vector3 mouseVector;
    public float x, z;
    public bool isColliding; //para ver se está colidindo com o cubo
    public GameObject cubeColliding;
    public GameObject pointGrab;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        float yValor = mouseVector.y;
        mouseVector.y += Input.GetAxis("Mouse X");
        mouseVector.z += Input.GetAxis("Mouse Y");
        x = Input.GetAxis("Vertical");
        z = -Input.GetAxis("Horizontal");

        RotateVision();

        MoveWithVision();

        CatchCube();
    }

    public void RotateVision()
    {
        transform.eulerAngles = new Vector3(0, mouseVector.y, mouseVector.z) * 10;
    }

    public void MoveWithVision()
    {   
        Vector3 move = transform.right * x + transform.forward * z;

        move.y = Physics.gravity.x * 12 * Time.deltaTime; //botei gravidade para não andar para cima

        move.Normalize();

        characterController.Move(move * Time.deltaTime * 5);     
    }

    public void CatchCube()
    {
        if(Input.GetKeyDown(KeyCode.Mouse0) && isColliding && !cubeColliding.transform.IsChildOf(gameObject.transform))
        {
            cubeColliding.transform.position = pointGrab.transform.position;
            cubeColliding.transform.parent = gameObject.transform;
            Debug.Log("Pegou");
        }

        else if(Input.GetKeyDown(KeyCode.Mouse0) && isColliding && cubeColliding.transform.IsChildOf(gameObject.transform))
        {
            cubeColliding.transform.parent = null;
            cubeColliding.AddComponent<Rigidbody>();
            Rigidbody rigid = cubeColliding.GetComponent<Rigidbody>();
            cubeColliding.transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log("Soltou");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag.Equals("Cube"))
        {
            isColliding = true;
            cubeColliding = collision.gameObject;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Cube"))
        {
            isColliding = false;
            cubeColliding = null;
        }
    }
}
