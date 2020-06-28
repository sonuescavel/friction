using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstPersonController : MonoBehaviour
{
    [Range (10f, 100f)]
    public float mouseSensitivity = 70f;
    float horizontal;
    float vertical;
    float mouseX;
    float mouseY;
    Quaternion deltaRotation;
    Vector3 deltaPosition;





    Rigidbody rbody;

    private void Start()
    {
        rbody = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        GetInputs();

        
    }

    private void FixedUpdates()
    {
        deltaRotation = Quaternion.Euler(Vector3.up * mouseX * mouseSensitivity * Time.fixedDeltaTime);
        rbody.MoveRotation(rbody.rotation * deltaRotation);


    }


    void GetInputs()
    {
        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
       

    }
        
    
}
