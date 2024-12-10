using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CarController : MonoBehaviour
{
    private Rigidbody rb;

    private float movementX;
    private float movementY;

    public float rotationSpeed = 50f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

   
    private void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3 (horizontalInput, 0, verticalInput).normalized;
        if(movement == Vector3.zero)
        {
            return;
        }

        Quaternion rotation = Quaternion.LookRotation(movement);
        rotation = Quaternion.RotateTowards(transform.rotation, rotation, 360*Time.fixedDeltaTime);

        rb.MovePosition(rb.position+ movement * 5 * Time.fixedDeltaTime);
        rb.MoveRotation(rotation);
        /*
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up, -rotationSpeed * Time.deltaTime, Space.World);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.right, rotationSpeed * Time.deltaTime, Space.World);
        }
        */
        
    }

    //void OnMove(InputValue movementValue)
    //{
      //  Vector2 movementVector = movementValue.Get<Vector2>();
      //  movementX = movementVector.x;
      //  movementY = movementVector.y;
    //}

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Building"))
        {
            Renderer buildingRenderer = collision.gameObject.GetComponent<Renderer>();
            if (buildingRenderer != null)
            {
                //buildingRenderer.material.color = Color.red; // Change color to red
                // Restore color after 1 second
  
                //StartCoroutine(ResetColor(buildingRenderer));
            }
        }
        else if (collision.gameObject.CompareTag("CarOther"))
        {
            Renderer buildingRenderer = collision.gameObject.GetComponent<Renderer>();

        }
    }

}
