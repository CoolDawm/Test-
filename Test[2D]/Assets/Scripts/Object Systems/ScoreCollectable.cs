using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoreCollectable : MonoBehaviour
{
    [SerializeField]
    private int _scoreAmount = 10;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ScoreUIManager scoreManager = FindAnyObjectByType<ScoreUIManager>();
            if (scoreManager != null)
            {
                scoreManager.AddScore(_scoreAmount);
            }
            Destroy(gameObject);
        }
    }
}
