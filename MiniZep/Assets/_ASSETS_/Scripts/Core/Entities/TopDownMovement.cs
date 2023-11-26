using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    [SerializeField] private float speed = 4.0f;
    [SerializeField] private Animator animator;

    private TopDownCharacterController controller;
    private Vector2 movementDir = Vector2.zero;
    private Rigidbody2D rigid;

    private void Awake()
    {
        controller = GetComponent<TopDownCharacterController>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDir);
    }

    private void Move(Vector2 direction)
    {
        movementDir = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= speed;
        rigid.velocity = direction;

        if (direction != Vector2.zero)
        {
            animator.SetBool("isRun", true);
        }
        else
        {   
            animator.SetBool("isRun", false);
        }
    }
}
