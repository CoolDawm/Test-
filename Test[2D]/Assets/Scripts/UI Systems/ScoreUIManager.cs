using TMPro;
using UnityEngine;

public class ScoreUIManager : MonoBehaviour
{
    [SerializeField]
    private int _score = 0;
    [SerializeField]
    private TextMeshProUGUI _scoreText;
    private void Start()
    {
        _scoreText.text = "Score: " + _score;
    }
    public void AddScore(int amount)
    {
        _score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (_scoreText != null)
        {
            _scoreText.text = "Score: " + _score;
        }
    }
}
