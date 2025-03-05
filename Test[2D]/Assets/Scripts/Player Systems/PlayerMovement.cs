using Terresquall;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(PlayerInput))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float _moveSpeed = 5f;
    [SerializeField]
    private bool _useGyro = false;

    private Rigidbody2D _rb;
    private Vector2 _movement;
    private PlayerInput _playerInput;
    private InputAction _moveAction;
    private UnityEngine.Gyroscope _gyro;

    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerInput = GetComponent<PlayerInput>();
        _moveAction = _playerInput.actions["Move"];

        if (_useGyro && SystemInfo.supportsGyroscope)
        {
            _gyro = Input.gyro;
            _gyro.enabled = true;
        }
    }

    void Update()
    {
        Vector2 joystickInput = VirtualJoystick.GetAxis();
        _movement = joystickInput;

        if (_useGyro && _gyro != null)
        {
            Vector3 gyroInput = _gyro.rotationRateUnbiased;
            _movement += new Vector2(gyroInput.x, gyroInput.y);
        }

        Vector2 keyboardInput = _moveAction.ReadValue<Vector2>();
        _movement += keyboardInput;
        _movement = _movement.normalized;
    }

    void FixedUpdate()
    {
        _rb.MovePosition(_rb.position + _movement * _moveSpeed * Time.fixedDeltaTime);
    }

    public void IncreaseSpeed(float value)
    {
        _moveSpeed += value;
    }

    public void DecreaseSpeed(float value)
    {
        _moveSpeed -= value;
    }
}