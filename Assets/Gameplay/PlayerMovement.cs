// based on Dave / GameDevelopment First Person Movement Tutorial
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	bool getsInputs;

	[Header("Movement")]
	private float movementSpeed;

	public float walkingSpeed;

	public float groundDrag;

	public float jumpForce;
	public float jumpCooldown;
	public float airMultiplier;
	bool readyToJump = true;

	[Header("Keybinds")]
	public KeyCode jumpKey = KeyCode.Space;

	[Header("Ground Check")]
	public float playerHeight;
	public LayerMask whatIsGround;
	bool grounded;

	public Transform orientation;

	float horizontalInput;
	float verticalInput;

	Vector3 moveDirection;

	Rigidbody rb;


	float graphicsHoppingProgress = 0;

	[Header("Hopping Animation")]
	[SerializeField] float graphicsHoppingSpeed;
	[SerializeField] float graphicsHoppingMaxDistance;

	float currentGraphicsHoppingDistance;
	[SerializeField] Transform graphicsHolder;
	SpriteRenderer sprite;

	[Header("State")]
	public MovementState state;
	public enum MovementState
	{
		walking,
		air
	}

    private void Awake()
    {
		rb = GetComponent<Rigidbody>();
		rb.freezeRotation = true;
		getsInputs = true;
		sprite = graphicsHolder.gameObject.GetComponentInChildren<SpriteRenderer>();
	}

	void FixedUpdate()
	{
		MovePlayer();
	}

	// Update is called once per frame
	void Update()
	{
		horizontalInput = 0;
		verticalInput = 0;

		// grounded check
		grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

		if (getsInputs) { GetInputs(); }
		LimitSpeed();
		StateHandler();

		// handle drag
		if (grounded)
		{
			rb.drag = groundDrag;
		}
		else
		{
			rb.drag = 0;
		}

		if (graphicsHolder != null)
        {
			currentGraphicsHoppingDistance = Mathf.Abs(Mathf.Sin(graphicsHoppingProgress)) * graphicsHoppingMaxDistance;
			graphicsHolder.localPosition = new Vector3(0, currentGraphicsHoppingDistance, 0);

			if (horizontalInput == 0) { }
			else if (horizontalInput > 0) 
			{
				graphicsHolder.transform.localScale = new Vector3(
					-Mathf.Abs(graphicsHolder.transform.localScale.x), 
					graphicsHolder.transform.localScale.y, 
					graphicsHolder.transform.localScale.z);
			}
			else
			{
				graphicsHolder.transform.localScale = new Vector3(
					Mathf.Abs(graphicsHolder.transform.localScale.x),
					graphicsHolder.transform.localScale.y,
					graphicsHolder.transform.localScale.z);
			}
		}
	}

	void GetInputs()
	{
		horizontalInput = Input.GetAxisRaw("Horizontal");
		verticalInput = Input.GetAxisRaw("Vertical");

		// jump
		if (Input.GetKey(jumpKey) && readyToJump && grounded)
		{
			readyToJump = false;
			Jump();

			Invoke(nameof(ResetJump), jumpCooldown);
		}
	}

	private void StateHandler()
	{
		if (grounded)
		{
			state = MovementState.walking;
			movementSpeed = walkingSpeed;
		}
		else
		{
			state = MovementState.air;
		}
	}

	void MovePlayer()
	{
		// calculate movement direction
		moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

		if (moveDirection.Equals(Vector3.zero)) 
		{
			graphicsHoppingProgress = 0;
			return; 
		}

		if (grounded)
		{
			rb.AddForce(moveDirection.normalized * movementSpeed * 10f, ForceMode.Force);
			UpdateHopping();
		}
		else
		{
			rb.AddForce(moveDirection.normalized * movementSpeed * 10f * airMultiplier, ForceMode.Force);
		}

	}

	void LimitSpeed()
	{
		Vector3 flatVelocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

		// limit velocity if needed
		if (flatVelocity.magnitude > movementSpeed)
		{
			Vector3 limitedVelocity = flatVelocity.normalized * movementSpeed;
			rb.velocity = new Vector3(limitedVelocity.x, rb.velocity.y, limitedVelocity.z);
		}
	}

	void Jump()
	{
		// reset y velocity
		rb.velocity = new Vector3(rb.velocity.x, 0, rb.velocity.z);

		graphicsHoppingProgress = 0;

		rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
	}

	void ResetJump()
	{
		readyToJump = true;
	}

	public void GetInputs(bool getInputs)
	{
		getsInputs = getInputs;
	}

	void UpdateHopping()
    {
		graphicsHoppingProgress += Time.deltaTime * graphicsHoppingSpeed;
		graphicsHoppingProgress %= 2 * Mathf.PI;
    }
}
