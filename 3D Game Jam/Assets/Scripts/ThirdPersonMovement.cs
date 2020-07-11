using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform Camera;
    public Transform groundCheck;
    public CharacterController Controller;

    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    private bool isGrounded = false;
    private float playerSpeed = 20.0f;
    private float jumpHeight = 1f;
    private float gravityValue = -9.81f;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;


    private void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        Debug.Log(isGrounded);

        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = -2f;
        }

        transform.rotation = Quaternion.Euler(0f, Camera.transform.rotation.eulerAngles.y, 0f);
        
        var move = transform.forward;
        Controller.Move(move * playerSpeed * Time.fixedDeltaTime);

        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        Controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

}
