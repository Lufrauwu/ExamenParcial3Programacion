using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public Text _scoreText = default;
    int score = 0;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        _scoreText.text = score.ToString() + " Points";
    }
    
    public void AddPoint()
    {
        score += 1;
        _scoreText.text = score.ToString() + " Points";
    }
}