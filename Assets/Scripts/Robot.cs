using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Robot : MonoBehaviour
{
    public Vector3 mouseVector;
    public float x, z;
    public bool isColliding; //para ver se está colidindo com o cubo
    public GameObject cubeColliding;
    public GameObject pointGrab;
    public Animator animator;
    public Rigidbody rigid;

    void Start()
    {
        animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float yValor = mouseVector.y;
        mouseVector.y += Input.GetAxis("Mouse X");
        mouseVector.z += Input.GetAxis("Mouse Y");
        x = Input.GetAxis("Horizontal");

        RotateVision();

        MoveWithVision();

        CatchCube();
    }

    public void RotateVision()
    {
        transform.eulerAngles = new Vector3(0, mouseVector.y, 0) * 10;
    }

    public void MoveWithVision()
    {
        if(Input.GetKey(KeyCode.A))
        {
            rigid.velocity = new Vector3(-10, 0, 0);
        }

        else if (Input.GetKey(KeyCode.D))
        {
            rigid.velocity = new Vector3(10, 0, 0);
        }

        else
        {
            rigid.velocity = new Vector3(0, 0, 0);
        }
    }

    public void CatchCube()
    {
        if(Input.GetKeyUp(KeyCode.Mouse0) && isColliding && !cubeColliding.transform.IsChildOf(gameObject.transform))
        {
            animator.SetBool("catch", true);
            cubeColliding.GetComponent<Rigidbody>().useGravity = false;
            cubeColliding.transform.position = pointGrab.transform.position;
            cubeColliding.transform.parent = gameObject.transform;
            cubeColliding.GetComponent<Cube>().platform.RemoveBlock(cubeColliding);
            Debug.Log("Pegou");
        }

        else if(Input.GetKeyUp(KeyCode.Mouse0) && isColliding && cubeColliding.transform.IsChildOf(gameObject.transform))
        {
            animator.SetBool("catch", false);
            isColliding = false;
            cubeColliding.transform.parent = null;
            cubeColliding.GetComponent<Rigidbody>().useGravity = true;
            cubeColliding.GetComponent<Rigidbody>().isKinematic = false;
            Rigidbody rigid = cubeColliding.GetComponent<Rigidbody>();
            cubeColliding.transform.rotation = Quaternion.Euler(0, 0, 0);
            rigid.constraints = RigidbodyConstraints.FreezeRotation;
            Debug.Log("Soltou");
        }

        else if(Input.GetKeyUp(KeyCode.Mouse0) || transform.GetComponentInChildren<Cube>())
        {
            animator.SetBool("catch", false);
        }

        else if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            animator.SetBool("catch", true);
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
