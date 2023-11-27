using UnityEngine;

public class TopDownRotation : MonoBehaviour
{
    [SerializeField] private SpriteRenderer characterRenderer;

    private TopDownCharacterController controller;

    private void Awake()
    {
        controller = GetComponent<TopDownCharacterController>();
    }

    private void Start()
    {
        controller.OnLookEvent += OnAim;
    }

    public void OnAim(Vector2 mousePosition)
    {
        ApplyRotate(mousePosition);
    }

    private void ApplyRotate(Vector2 mousePosition)
    {
        if (Manager.Game.State == GameState.Pause) return;

        // ���콺 ��ġ�� �÷��̾� ��ġ�� ���� �������� ����
        Vector2 direction = mousePosition - (Vector2)transform.position;
        characterRenderer.flipX = direction.x <= 0;
    }
}
