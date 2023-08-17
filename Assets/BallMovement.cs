using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _initialForce; // Начальная сила для запуска мяча
    [SerializeField] private float _maxSpeed; // Максимальная скорость мяча
    [SerializeField] private float _collisionAcceleration = 1.2f; // Ускорение при столкновении
    [SerializeField] private float _randomDirectionRangeX = 0.2f; // Диапазон случайного направления по X
    [SerializeField] private float _randomDirectionRangeY = 0.2f; // Диапазон случайного направления по Y

    private Rigidbody2D _ballRigidbody2D; // Ссылка на компонент Rigidbody2D мяча
    private Vector2 _initialPosition; // Исходная позиция мяча

    private void Awake()
    {
        _ballRigidbody2D = GetComponent<Rigidbody2D>();
        _initialPosition = transform.position;
    }

    private void Start()
    {
        LaunchBall(); // Запуск мяча при старте
    }

    private void FixedUpdate()
    {
        LimitSpeed(); // Ограничение максимальной скорости мяча
    }

    private void LaunchBall()
    {
        float randomDirectionX = Random.Range(-_randomDirectionRangeX, _randomDirectionRangeX);
        float randomDirectionY = Random.Range(-_randomDirectionRangeY, _randomDirectionRangeY);
        Vector2 launchDirection = new Vector2(randomDirectionX, randomDirectionY).normalized;

        _ballRigidbody2D.AddForce(launchDirection * _initialForce, ForceMode2D.Impulse); // Применение начальной силы
    }

    private void LimitSpeed()
    {
        float currentSpeed = _ballRigidbody2D.velocity.magnitude;
        if (currentSpeed > _maxSpeed)
        {
            _ballRigidbody2D.velocity = _ballRigidbody2D.velocity.normalized * _maxSpeed;
        }
    }

    // Вызывается при столкновении мяча с другим объектом
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Применение ускорения при столкновении
        _ballRigidbody2D.velocity += _ballRigidbody2D.velocity.normalized * (_collisionAcceleration - 1f);

        // Применение случайного влияния на направление мяча при столкновении
        Vector2 randomDirection = new Vector2(Random.Range(-_randomDirectionRangeX, _randomDirectionRangeX),
                                              Random.Range(-_randomDirectionRangeY, _randomDirectionRangeY)).normalized;

        _ballRigidbody2D.velocity = (_ballRigidbody2D.velocity + randomDirection).normalized * _ballRigidbody2D.velocity.magnitude;
    }

    public void RespawnBall()
    {
        transform.position = _initialPosition; // Возвращаем мяч на исходную позицию
        _ballRigidbody2D.velocity = Vector2.zero; // Сбрасываем скорость
        LaunchBall(); // Запускаем мяч заново
    }
}