using System.Runtime.Remoting.Messaging;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform Camera;
    public CharacterController Controller;

    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    private bool isGrounded = false;
    private float playerSpeed = 20.0f;
    private float jumpHeight = 1.5f;
    private float gravityValue = -9.81f;
    //private float previousTransformY;

    private void FixedUpdate()
    {
        isGrounded = Controller.isGrounded;
        if (isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        transform.rotation = Quaternion.Euler(0f, Camera.transform.rotation.eulerAngles.y, 0f);
        
        var move = transform.forward;
        Controller.Move(move * playerSpeed * Time.fixedDeltaTime);

        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}

        // Changes the height position of the player..
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        playerVelocity.y += gravityValue * Time.fixedDeltaTime;
        Controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

}
