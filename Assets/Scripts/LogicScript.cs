using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        playerScore = playerScore +1;
        scoreText.text = playerScore.ToString();
    }

}
