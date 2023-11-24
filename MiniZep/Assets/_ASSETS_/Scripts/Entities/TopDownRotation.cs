using UnityEngine;

public class TopDownRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController _controller;

    private void Awake()
    {
        _controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        _controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 mousePosition)
    {
        FlipPlayer(mousePosition);
    }

    private void FlipPlayer(Vector2 mousePosition)
    {
        // ���콺 ��ġ�� �÷��̾� ��ġ�� ���� �������� ����
        Vector2 direction = mousePosition - (Vector2)transform.position;

        float rotZ = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        characterRenderer.flipX = Mathf.Abs(rotZ) > 90f;
    }
}
