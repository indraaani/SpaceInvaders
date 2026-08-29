using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public GameObject GameOverScreen;
    public ShipScript shipScript;
    public TextMeshProUGUI shipHealthText;

    [ContextMenu("Increase Score")]
    public void AddScore()
    {
        playerScore = playerScore +1;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Update Ship Health")]
    public void UpdateShipHealth()
    {
        shipHealthText.text = shipScript.shipHealth.ToString();
    }

    public void GameOver()
    {
        GameOverScreen.SetActive(true);

        foreach (GameObject Enemy in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                Destroy(Enemy);
            }

    }
        public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
