using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Vision : MonoBehaviour
{
    public float sensitivity = 3f;
    public float smoothing = 3f;

    private Camera _camera;
    private Vector2 _smoothVector;
    private Vector2 _previousInputState = new Vector2(0, 0);

    private void Awake()
    {
        _camera = GetComponentInChildren<Camera>();
    }

    private void FixedUpdate()
    {
        GetInput();
    }

    private void GetInput()
    {
#if UNITY_STANDALONE || UNITY_WEBPLAYER
        var inputDirection = new Vector2(0.1f * Input.GetAxisRaw("Mouse X"),
                                 0.1f * Input.GetAxisRaw("Mouse Y"));
#elif UNITY_IOS || UNITY_ANDROID || UNITY_WP8 || UNITY_IPHONE
        var inputDirection = new Vector2(0.1f * CrossPlatformInputManager.GetAxisRaw("LookAtHorizontal"),
                                 0.1f * CrossPlatformInputManager.GetAxisRaw("LookAtVertical"));
#endif


        inputDirection = Vector2.Scale(inputDirection, new Vector2(sensitivity * smoothing, sensitivity * smoothing));
        _smoothVector = Vector2.Lerp(_smoothVector, inputDirection, 1f / smoothing);

        _previousInputState += _smoothVector;

        _previousInputState.y = Mathf.Clamp(_previousInputState.y, -90f, 90f);

        transform.localRotation = Quaternion.AngleAxis(_previousInputState.x, transform.up);
        _camera.transform.localRotation = Quaternion.AngleAxis(-_previousInputState.y, Vector3.right);

    }
}
