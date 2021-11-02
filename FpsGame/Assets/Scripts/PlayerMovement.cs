using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Speed variable
    [SerializeField]
    private float speed = 16f;

    // Gravity variable, how fast the player falls
    [SerializeField]
    private float gravity = -39.24f;

    // How fast the player moves upwards when they jump
    [SerializeField]
    private float jumpHeight = 4f;

    // Speed when running
    [SerializeField]
    private float run = 26f;

    // Variable for checking if the player is on the ground
    public Transform groundCheck;

    // THe variable that decides how far away the player is for the gravity to stop building speed
    public float groundDistance = 0.4f;

    // Think it decides which surface is the ground
    public LayerMask groundMask;

    // Decides which key is sprint, useful for later when buttons are customizable
    public KeyCode sprint;

    // Creates new Vector in a 3d space that is edited later
    Vector3 velocity;

    // Has 2 jobs, to say when the player is on the ground, and off the ground. Bool is like a switch.
    bool isGrounded;

    // Update is called once per frame
    void Update()
    {
        // Checks if the Sphere is far enough from the ground for gravity to stop pulling the player down
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // An if statement that says if the player isn't grounded, it will move downwards.
        // It will move constantly towards
        if(isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
        }

        // The code for the movement, decides with getAxis how the player moves horizontally and vertically.
        // GetAxis makes the movement smoother, increases movement and decreases it not instantly so that it becomes smoother.
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Defines what "move" is with a vector, also using transform.right and transform.forward so that the way the player moves
        // is related to the rotation of the player.
        Vector3 move = transform.right * x + transform.forward * z;

        // Makes it the player's choice what the sprint button is, and multiplies the run variable with the 
        // move vector, making it function as a sprint. The else part of the if statement just tells the program to
        // always move at a normal speed until the shift key is pressed.
        if(Input.GetKey(sprint))
        {
            controller.Move(run * Time.deltaTime * move);
        }
        else
        {
            controller.Move(speed * Time.deltaTime * move);
        }

        // When the jump button is pressed, the player jumps using the formula below, where jumpheight multiplied with -2 and gravity 
        // is the amount of space that will be jumped
        if(Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2 * gravity);
        }

        // The formula for gravity, so that the player doesn't just float
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
