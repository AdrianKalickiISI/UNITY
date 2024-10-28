using UnityEngine;

public class MovingPlatformani : MonoBehaviour
{
    public Transform startPoint;          
    public Transform endPoint;            
    public float platformSpeed = 3f;      

    private bool isMoving = false;        
    private bool movingToEnd = true;      
    private Transform playerTransform;    

    void Update()
    {
        if (isMoving)
        {
            MovePlatform();
        }
    }

    private void MovePlatform()
    {
        Vector3 targetPosition = movingToEnd ? endPoint.position : startPoint.position;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, platformSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
        {
            movingToEnd = !movingToEnd;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = true; 
            playerTransform = other.transform;

            
            other.transform.parent = transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isMoving = false; 
            playerTransform = null;

            
            other.transform.parent = null;
        }
    }
}
