using UnityEngine;

public class GameController : MonoBehaviour
{
    private const int scoreModifier = 2;

    private PlayerController playerControllerScript;

    private int scoreUpdate = 1;
    private int score;

    private void Start()
    {
        score = 0;
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (playerControllerScript.obstaclePassed)
        {
            if (playerControllerScript.dashPressed)
            {
                score += scoreUpdate * scoreModifier;
                Debug.Log(score);
            }
            else
            {
                score += scoreUpdate;
                Debug.Log(score);
            }
        }
    }
}
