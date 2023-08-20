using UnityEngine;

public class EnemyGoalTrigger : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem; // Привязать ScoreSystem через инспектор
    [SerializeField] private BallMovement _ballMovement; // Привязать BallMovement через инспектор
    [SerializeField] private GameInitializer _gameInitializer;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallMovement>() != null)
        {
            _scoreSystem.EnemyScored();
            if (_gameInitializer._gameStarted)
            {
                _ballMovement.RespawnBall(); // Вызов метода для переброса мяча на центр поля
            }
        }
    }
}