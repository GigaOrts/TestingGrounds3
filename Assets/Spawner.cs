using UnityEngine;

public class Spawner : MonoBehaviour
{
    private float repeatRate = 1.5f;
    private float startDelay = 2f;
    [SerializeField] private GameObject obstaclePrefab;
    [SerializeField] private Transform spawnPosition;

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObstacle), startDelay, repeatRate);
    }

    private void SpawnObstacle()
    {
        Instantiate(obstaclePrefab, spawnPosition.position, obstaclePrefab.transform.rotation);
    }
}
