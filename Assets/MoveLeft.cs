using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";
    private PlayerController playerControllerScript;
    private float speed = 10f;

    private void Start()
    {
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (playerControllerScript.isGameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);

        if (transform.position.x < -5f && gameObject.CompareTag(ObstacleTag))
            Destroy(gameObject);
    }
}
