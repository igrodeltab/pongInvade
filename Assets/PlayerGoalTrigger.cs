using UnityEngine;

public class PlayerGoalTrigger : MonoBehaviour
{
    [SerializeField] private ScoreSystem _scoreSystem; // Привязать ScoreSystem через инспектор

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<BallMovement>() != null)
        {
            _scoreSystem.PlayerScored();
        }
    }
}