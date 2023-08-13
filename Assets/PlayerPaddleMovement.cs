using UnityEngine;

public class PlayerPaddleMovement : MonoBehaviour
{
    [SerializeField] private float _playerPaddleMovementSpeed; // Скорость перемещения платформы
    [SerializeField] private float _verticalPadding; // Вертикальный отступ от границы экрана

    private Rigidbody2D _playerPaddleRigidbody2D; // Ссылка на компонент Rigidbody2D платформы
    private float _verticalInput; // Значение вертикального ввода

    private void Awake()
    {
        _playerPaddleRigidbody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _verticalInput = Input.GetAxisRaw("Vertical"); // Получение вертикального ввода
    }

    private void FixedUpdate()
    {
        Vector2 velocity = new Vector2(0f, _verticalInput * _playerPaddleMovementSpeed);
        _playerPaddleRigidbody2D.velocity = velocity;
    }
}