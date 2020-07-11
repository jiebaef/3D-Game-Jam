using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform Camera;
    public Transform groundCheck;
    public CharacterController Controller;

    public float playerSpeed = 25f,
                    jumpHeight = 4f,
                    jumpPower = 2f,
                    gravityMultiplier = 0.15f;

    private Vector3 playerVelocity = new Vector3(0, 0, 0);
<<<<<<< HEAD
    private bool isGrounded, canJump;

    private void Start()
    {
        canJump = isGrounded = Controller.isGrounded;
    }

    private void FixedUpdate()
    {
        isGrounded = Controller.isGrounded;
=======
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
>>>>>>> origin/Tim2

        RotateCharacterTowardsCameraAim();

        MoveCharacterTowardsRotation();

        ExecuteIfJumped();

        AddGravityToCharacter();
    }

    private void RotateCharacterTowardsCameraAim() => transform.rotation = Quaternion.Euler(0f, Camera.transform.rotation.eulerAngles.y, 0f);

<<<<<<< HEAD
    private void MoveCharacterTowardsRotation() => Controller.Move(transform.forward * playerSpeed * Time.fixedDeltaTime);

    private void ExecuteIfJumped()
    {
        if (!canJump) return;

        if (Input.GetKey(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Pow(jumpHeight, jumpPower);
            Controller.Move(playerVelocity * Time.fixedDeltaTime);
            canJump = false;
        }
    }

    private void AddGravityToCharacter()
    {
        if (isGrounded)
=======
        if (Input.GetKey(KeyCode.Space) && isGrounded)
>>>>>>> origin/Tim2
        {
            playerVelocity = Vector3.zero;
            canJump = true;
            return;
        }

        playerVelocity.y += Physics.gravity.y * gravityMultiplier;
        Controller.Move(playerVelocity * Time.fixedDeltaTime);
    }

}
