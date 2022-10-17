using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRigidbody;

    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerRigidbody.AddForce(Vector3.up * 500);
    }

    void Update()
    {
        
    }
}
