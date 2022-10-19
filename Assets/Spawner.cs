using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] obstaclePrefabs;
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
        int randomIndex = Random.Range(0, obstaclePrefabs.Length);

        if (playerControllerScript.isGameOver == false)
            Instantiate(obstaclePrefabs[randomIndex], spawnPosition.position, obstaclePrefabs[randomIndex].transform.rotation);
    }
}
