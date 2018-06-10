using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Movement : MonoBehaviour
{
    public float maxMovementSpeed;

    private Rigidbody _rb;

	void Start ()
    {
        _rb = GetComponent<Rigidbody>();
	}

    private void FixedUpdate()
    {
        GetJoystickInput();
    }

    private void GetJoystickInput()
    {
        var horizontalAxis = CrossPlatformInputManager.GetAxis("Horizontal");
        var verticalAxis = CrossPlatformInputManager.GetAxis("Vertical");

        var inputDirection = new Vector3(horizontalAxis, 0, verticalAxis);
        inputDirection.Normalize();
        inputDirection = transform.TransformDirection(inputDirection * maxMovementSpeed);

        _rb.velocity = inputDirection;
    }
}
