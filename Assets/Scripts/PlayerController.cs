using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0f;

    private Animator animator;
    private Vector3 _up, _down, _left, _right;
    private Vector3 _currentDirection, _initialPosition;

    // Start is called before the first frame update
    private void Start()
    {
        _up = Vector3.zero;
        _down = new Vector3(0, 180, 0);
        _left = new Vector3(0, 270, 0);
        _right = new Vector3(0, 90, 0);
        _currentDirection = Vector3.zero;

        _initialPosition = transform.position;
        animator = GetComponent<Animator>();
        Reset();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
    }

    //Moves the player whenever they press a Keyboard (W,A,S,D or up,down,left,right) or Gamepad (dpad up,down,left,right or left stick)
    private void MovePlayer()
    {
        Gamepad gamepad = Gamepad.current;
        Keyboard keyboard = Keyboard.current;

        bool isMoving = true;
        bool isDead = animator.GetBool("isDead");

        if (isDead)
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
        else if (keyboard != null && (keyboard.upArrowKey.isPressed || keyboard.wKey.isPressed) || gamepad != null && (gamepad.dpad.up.isPressed || gamepad.leftStick.y.ReadValue() == 1))
        {
            _currentDirection = _up;
            transform.localEulerAngles = _currentDirection;
            animator.SetBool("isMoving", isMoving);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else if (keyboard != null && (keyboard.downArrowKey.isPressed || keyboard.sKey.isPressed) || gamepad != null && (gamepad.dpad.down.isPressed || gamepad.leftStick.y.ReadValue() == -1))
        {
            _currentDirection = _down;
            transform.localEulerAngles = _currentDirection;
            animator.SetBool("isMoving", isMoving);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else if (keyboard != null && (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed) || gamepad != null && (gamepad.dpad.left.isPressed || gamepad.leftStick.x.ReadValue() == -1))
        {
            _currentDirection = _left;
            transform.localEulerAngles = _currentDirection;
            animator.SetBool("isMoving", isMoving);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else if (keyboard != null && (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed) || gamepad != null && (gamepad.dpad.right.isPressed || gamepad.leftStick.x.ReadValue() == 1))
        {
            _currentDirection = _right;
            transform.localEulerAngles = _currentDirection;
            animator.SetBool("isMoving", isMoving);
            transform.Translate(Vector3.forward * movementSpeed * Time.deltaTime);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Enemy"))
            animator.SetBool("isDead",true);
    }

    //Start game or reset position when Pac-Man dies
    public void Reset()
    {
        transform.position = _initialPosition;
        animator.SetBool("isDead", false);
        animator.SetBool("isMoving", false);
        _currentDirection = _down;
    }
}
