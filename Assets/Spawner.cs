using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPosition;

    private PlayerController playerControllerScript;
    private float repeatRate = 1.5f;
    private float startDelay = 2f;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
        playerControllerScript = FindObjectOfType<PlayerController>();
    }

    private void SpawnObstacle()
    {
        if (playerControllerScript.isGameOver == false)
            Instantiate(obstaclePrefab, spawnPosition.position, obstaclePrefab.transform.rotation);
    }
}
