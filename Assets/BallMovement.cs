using UnityEngine;

public class BallMovement : MonoBehaviour
{
    [SerializeField] private float _initialForce; // Начальная сила для запуска мяча
    [SerializeField] private float _maxSpeed; // Максимальная скорость мяча

    private Rigidbody2D _ballRigidbody2D; // Ссылка на компонент Rigidbody2D мяча

    private void Awake()
    {
        _ballRigidbody2D = GetComponent<Rigidbody2D>();
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
        float randomDirection = Random.Range(0, 2) == 0 ? -1 : 1; // Случайное направление запуска мяча по X
        Vector2 launchDirection = new Vector2(randomDirection, Random.Range(-0.5f, 0.5f)).normalized;

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
        // Применение случайного влияния на направление мяча при столкновении
        Vector2 randomDirection = new Vector2(Random.Range(-0.2f, 0.2f), Random.Range(-0.2f, 0.2f)).normalized;
        _ballRigidbody2D.velocity = (_ballRigidbody2D.velocity + randomDirection).normalized * _ballRigidbody2D.velocity.magnitude;
    }
}