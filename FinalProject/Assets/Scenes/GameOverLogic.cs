using TMPro;
using UnityEngine;

public class GameOverLogic : MonoBehaviour
{
    [SerializeField] GameObject gameOverScreen;
    [SerializeField] pulpitManager manager;
    [SerializeField] TMP_Text scoreText;
    [SerializeField] GameObject scoreTextIngame;

    [SerializeField] MovementScript movement;

    private void Start()
    {
        gameOverScreen.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        gameOverScreen.SetActive(true);
        manager.enabled = false;
        movement.enabled = false;
        scoreTextIngame.SetActive(false);

        scoreText.text = "Score: " + manager.score.ToString();
    }
}
