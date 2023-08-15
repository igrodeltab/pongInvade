using UnityEngine;

public class PlayerGoalTrigger : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem; // Привязать ScoreSystem через инспектор
    [SerializeField] private BallMovement _ballMovement; // Привязать BallMovement через инспектор

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallMovement>() != null)
        {
            _scoreSystem.PlayerScored();
            _ballMovement.RespawnBall(); // Вызов метода для переброса мяча на центр поля
        }
    }
}