using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xClamp = 3f;
    [SerializeField] float zClamp = 3f;

    // public JumpWithCurve pjump;
    // public float _startY;
    // private PlayerControla inputControls;

    Vector2 movement;
    Rigidbody rigidBody;


    void Awake()
    {
        //inputControls = new PlayerControla();
        rigidBody = GetComponent<Rigidbody>();
        //pjump = GetComponent<JumpWithCurve>();
    }

    // private void OnEnable()
    // {
    //     inputControls.Enable();
    //     inputControls.Player.Jump.started += OnJump;
    // }

    // private void OnDisable()
    // {
    //     inputControls.Player.Jump.started += OnJump;
    //     inputControls.Disable();
    // }

    // private void Start()
    // {
    //     _startY = gameObject.transform.position.y;
    // }

    void FixedUpdate()
    {
        HandleMovement();
    }

    // private void OnJump(InputAction.CallbackContext ctx)
    // {
    //     pjump.move_y(gameObject);
    // }
    public void Move(InputAction.CallbackContext context)
    {
        movement = context.ReadValue<Vector2>();
    }

    void HandleMovement()
    {
        Vector3 currentPosition = rigidBody.position;
        Vector3 moveDirection = new Vector3(movement.x, 0f, movement.y);
        Vector3 newPosition = currentPosition + moveDirection * (moveSpeed * Time.fixedDeltaTime);

        newPosition.x = Mathf.Clamp(newPosition.x, -xClamp, xClamp);
        newPosition.z = Mathf.Clamp(newPosition.z, -zClamp, zClamp);

        rigidBody.MovePosition(newPosition);
    }
}