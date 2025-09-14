using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField] private float moveSpeed = 5;
    [SerializeField] private float jumpForce = 5;
    private float moveDirection;

    private Rigidbody2D rigidbody;

    private IsGroundedChecker isgroundedChecker;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        isgroundedChecker = GetComponent<IsGroundedChecker>();
    }


    private void Start()
    {
        GameManager.Instance.InputManager.OnJump += HandleJump;
        inputManager = new InputManager();
    }

        private void Update()
    {
        MovePlayer();
        FlipSpriteAccordingToMoveDirection();
    }

    private void MovePlayer()
    {
        moveDirection = GameManager.Instance.InputManager.Movement;
        transform.Translate(moveDirection * Time.deltaTime * moveSpeed, 0, 0);
    }

    private void FlipSpriteAccordingToMoveDirection()
    {
        if (moveDirection < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (moveDirection > 0)
        {
            transform.localScale = Vector3.one;
        }
    }

    private void HandleJump()
    {
        if (!isgroundedChecker.IsGrounded()) 
            return;
        rigidbody.linearVelocity += Vector2.up * jumpForce;

    }

}