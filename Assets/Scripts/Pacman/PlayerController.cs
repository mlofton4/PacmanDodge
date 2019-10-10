using System.Collections;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 0f;
    [SerializeField] private AudioSource audiodata = null;

    private Animator animator;
    private Vector3 _initialPosition;
    private bool performed;

    // Start is called before the first frame update
    private void Start()
    {
        _initialPosition = transform.position;
        animator = GetComponent<Animator>();
        performed = false;

        Reset();
        if (performed == false)
        {
            StartCoroutine(StartGame());
        }
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



        if (performed == false)
        {
            return;
        }
        else if (isDead)
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }
        else if (keyboard != null && (keyboard.upArrowKey.isPressed || keyboard.wKey.isPressed) || gamepad != null && (gamepad.dpad.up.isPressed || gamepad.leftStick.y.ReadValue() == 1))
        {
            animator.SetBool("isMoving", isMoving);
            transform.position += Vector3.forward * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.forward);
        }
        else if (keyboard != null && (keyboard.downArrowKey.isPressed || keyboard.sKey.isPressed) || gamepad != null && (gamepad.dpad.down.isPressed || gamepad.leftStick.y.ReadValue() == -1))
        {
            animator.SetBool("isMoving", isMoving);
            transform.position += Vector3.back * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.back);
        }
        else if (keyboard != null && (keyboard.leftArrowKey.isPressed || keyboard.aKey.isPressed) || gamepad != null && (gamepad.dpad.left.isPressed || gamepad.leftStick.x.ReadValue() == -1))
        {
            animator.SetBool("isMoving", isMoving);
            transform.position += Vector3.left * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.left);
        }
        else if (keyboard != null && (keyboard.rightArrowKey.isPressed || keyboard.dKey.isPressed) || gamepad != null && (gamepad.dpad.right.isPressed || gamepad.leftStick.x.ReadValue() == 1))
        {
            animator.SetBool("isMoving", isMoving);
            transform.position += Vector3.right * movementSpeed * Time.deltaTime;
            transform.rotation = Quaternion.LookRotation(Vector3.right);
        }
        else
        {
            isMoving = false;
            animator.SetBool("isMoving", isMoving);
        }

    }

    //Die whenever a ghost hits us
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
        transform.rotation = Quaternion.LookRotation(Vector3.back);
    }

    //Wait until the music plays to start the game
    private IEnumerator StartGame()
    {
        audiodata.Play();
        yield return new WaitForSeconds(audiodata.clip.length - 0.5f);
        performed = true;
    }
}
