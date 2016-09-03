using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    // Movement speed for player
    public float movementSpeed;

	// Player animator
	private Animator movementAnimator;

    // Use this for initialization
    void Start () {
		// Get player animator
		movementAnimator = GetComponent<Animator>();
    }
	
    // Update is called once per frame
    void Update ()
    {
		// Get input axes
        float horizontalAxis = Input.GetAxisRaw("Horizontal");
        float verticalAxis = Input.GetAxisRaw("Vertical");

        // Horizontal movement
        if (horizontalAxis > 0.5f || horizontalAxis < -0.5f)
        {
			transform.Translate(new Vector3(
				horizontalAxis * movementSpeed * Time.deltaTime,
				0f,
				0f
			));
        }

        // Vertical movement
        if (verticalAxis > 0.5f || verticalAxis < -0.5f)
        {
			transform.Translate(new Vector3(
                0f,
				verticalAxis * movementSpeed * Time.deltaTime,
                0f
			));
        }

		// Update animator
		movementAnimator.SetFloat("MovementX", horizontalAxis);
		movementAnimator.SetFloat("MovementY", verticalAxis);
    }
}
