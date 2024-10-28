using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private CharacterController controller;  
    private Vector3 playerVelocity;          
    private bool groundedPlayer;             
    public float playerSpeed = 5.0f;         
    public float jumpHeight = 1.5f;          
    public float gravityValue = -9.81f;      

    private void Start()
    {
        
        controller = GetComponent<CharacterController>();
        if (controller == null)
        {
            Debug.LogError("Brak komponentu CharacterController na obiekcie gracza! Dodaj go do gracza.");
        }
    }

    void Update()
    {
        
        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        controller.Move(move * Time.deltaTime * playerSpeed);

        
        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravityValue);
        }

        
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Rozpoczęto kontakt z przeszkodą.");
        }
    }
}
