using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public Transform Camera;
    public CharacterController Controller;

    public float    playerSpeed = 25f,
                    jumpHeight = 4f,
                    jumpPower = 2f,
                    gravityMultiplier = 0.15f;

    private Vector3 playerVelocity = new Vector3(0, 0, 0);
    private bool isGrounded, canJump;
    private float previousTransformY;

    private void Start()
    {
        previousTransformY = -1000f;
        canJump = isGrounded = Controller.isGrounded;
    }

    private void FixedUpdate()
    {
        isGrounded = Controller.isGrounded;

        RotateCharacterTowardsCameraAim();

        MoveCharacterTowardsRotation();

        ExecuteIfJumped();

        AddGravityToCharacter();
    }

    private void RotateCharacterTowardsCameraAim() => transform.rotation = Quaternion.Euler(0f, Camera.transform.rotation.eulerAngles.y, 0f);

    private void MoveCharacterTowardsRotation() => Controller.Move(transform.forward * playerSpeed * Time.fixedDeltaTime);

    private void ExecuteIfJumped()
    {
        if(!canJump) return;

        if(Input.GetKey(KeyCode.Space))
        {
            playerVelocity.y += Mathf.Pow(jumpHeight, jumpPower);
            Controller.Move(playerVelocity * Time.fixedDeltaTime);
            canJump = false;
        }
    }

    private void AddGravityToCharacter()
    {
        if (isGrounded)
        {
            playerVelocity = Vector3.zero;
            previousTransformY = transform.position.y;
            canJump = true;
            return;
        }

        if (previousTransformY != transform.position.y)
        {
            playerVelocity.y += Physics.gravity.y * gravityMultiplier;
            Controller.Move(playerVelocity * Time.fixedDeltaTime);
        }
    }

}
