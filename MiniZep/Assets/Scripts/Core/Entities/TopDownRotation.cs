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
        if (Main.Game.State == GameState.Pause) return;

        // 마우스 위치에 플레이어 위치를 빼야 기준점이 잡힘
        Vector2 direction = mousePosition - (Vector2)transform.position;
        characterRenderer.flipX = direction.x <= 0;
    }
}
