using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement speed for player
    public float movementSpeed;

	// Player animator
	private Animator animator;

	// Whether the player is currently moving
	private bool isPlayerMoving;

	// Where the player was headed last time, (x, y)
	private Vector2 lastMovement;

    // Use this for initialization
    void Start () {
		// Get player animator
		animator = GetComponent<Animator>();
		isPlayerMoving = false;
    }
	
    // Update is called once per frame
    void Update ()
    {
		// Not moving by default
		isPlayerMoving = false;

		// Get input axes
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

		// Whether the axises have any activity
		bool hasActiveHorizontal = horizontalAxis > 0.5f || horizontalAxis < -0.5f;
		bool hasActiveVertical = verticalAxis > 0.5f || verticalAxis < -0.5f;

        // Horizontal movement
		if (hasActiveHorizontal)
        {
			transform.Translate(new Vector3(
				horizontalAxis * movementSpeed * Time.deltaTime,
				0f,
				0f
			));
        }

        // Vertical movement
		if (hasActiveVertical)
        {
			transform.Translate(new Vector3(
                0f,
				verticalAxis * movementSpeed * Time.deltaTime,
                0f
			));
        }

		// Update movement flag
		if (hasActiveHorizontal || hasActiveVertical)
		{
			isPlayerMoving = true;
			lastMovement = new Vector2(horizontalAxis, verticalAxis);
		}

		// Update animator props
		animator.SetFloat("MovementX", horizontalAxis);
		animator.SetFloat("MovementY", verticalAxis);
		animator.SetFloat("LastMovementX", lastMovement.x);
		animator.SetFloat("LastMovementY", lastMovement.y);
		animator.SetBool("CurrentlyMoving", isPlayerMoving);
    }
}
