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
        // 게임 상태가 Pause 일 경우 => return, 움직임 제어
        if (Manager.Game.State == GameState.Pause)
        {
            rigid.velocity = Vector2.zero;
            animator.SetBool("isRun", false);
            return;
        }

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
