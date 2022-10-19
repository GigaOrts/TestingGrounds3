using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    private const string ObstacleTag = "Obstacle";

    private PlayerController playerControllerScript;

    public float speed { get; } = 10f;
    private float speedModifier = 1.5f;
    private float dashSpeed;

    public float currentSpeed { get; private set; } = 0f;

    private void Start()
    {
        currentSpeed = speed;
        dashSpeed = speed * speedModifier;

        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(playerControllerScript.DashKey))
            currentSpeed = playerControllerScript.dashPressed ? dashSpeed : speed;

        if (playerControllerScript.isGameOver == false)
            transform.Translate(Vector3.left * Time.deltaTime * currentSpeed, Space.World);

        if (transform.position.x < -5f && gameObject.CompareTag(ObstacleTag))
            Destroy(gameObject);
    }
}
