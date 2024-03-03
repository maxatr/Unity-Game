using UnityEngine;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private Text hpText;
    [SerializeField] private Text levelText;
    [SerializeField] private Text scoreText;

    public void UpdateScoreAndLevel()
    {
        levelText.text = $"Level {Stats.Level}";
        scoreText.text = "Score: " + Stats.Score.ToString("D4");
    }
    
    public void UpdateHp(int hp)
    {
        hpText.text = $"Level {hp}";
    }
}
