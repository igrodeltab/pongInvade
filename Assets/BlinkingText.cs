using UnityEngine;
using TMPro;

public class BlinkingText : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _text; // Ссылка на компонент текста
    [SerializeField] private float _blinkSpeed; // Скорость мерцания

    private bool _isVisible = true; // Флаг для отслеживания видимости текста
    private float _timer; // Таймер для мерцания

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= _blinkSpeed) // Если прошло достаточно времени для мигания
        {
            _isVisible = !_isVisible; // Инвертируем видимость текста
            _text.enabled = _isVisible; // Применяем измененную видимость к тексту
            _timer = 0f; // Сбрасываем таймер
        }
    }
}