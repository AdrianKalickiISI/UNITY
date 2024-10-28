using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    public float launchForce = 15f; 

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            
            Rigidbody playerRb = other.GetComponent<Rigidbody>();

            if (playerRb != null)
            {
                
                Vector3 launchDirection = Vector3.up * launchForce;
                playerRb.AddForce(launchDirection, ForceMode.Impulse);
            }
        }
    }
}
