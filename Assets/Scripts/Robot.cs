using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public CharacterController characterController;
    public Vector3 mouseVector;
    public float x, z;

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
}
