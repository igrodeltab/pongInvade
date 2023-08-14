using UnityEngine;

public class EnemyPaddleAI : MonoBehaviour
{
    [SerializeField] private Transform _ballTransform; // Ссылка на трансформ мяча
    [SerializeField] private float _movementSpeed; // Скорость движения платформы

    private Rigidbody2D _paddleRigidbody2D; // Ссылка на компонент Rigidbody2D платформы

    private void Awake()
    {
        _paddleRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Получаем направление движения к мячу
        Vector2 directionToBall = (_ballTransform.position - transform.position).normalized;

        // Устанавливаем скорость движения платформы в заданное направление
        Vector2 velocity = new Vector2(0f, directionToBall.y) * _movementSpeed;
        _paddleRigidbody2D.velocity = velocity;
    }
}