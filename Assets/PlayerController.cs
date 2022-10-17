using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float gravityModifier = 1f;
    [SerializeField] private float jumpForce;

    private Rigidbody playerRigidbody;
    private bool isOnGround;

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround)
        {
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        isOnGround = true;
    }
}
