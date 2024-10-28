using UnityEngine;

public class SlidingDoor : MonoBehaviour
{
    public Transform closedPosition;    
    public Transform openPosition;      
    public float speed = 3.0f;          
    public float detectionRange = 3.0f; 

    private Transform player;           
    private bool isOpen = false;        

    private void Start()
    {
        
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        
        if (Vector3.Distance(player.position, transform.position) < detectionRange)
        {
            isOpen = true; 
        }
        else
        {
            isOpen = false; 
        }

        
        if (isOpen)
        {
            transform.position = Vector3.MoveTowards(transform.position, openPosition.position, speed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, closedPosition.position, speed * Time.deltaTime);
        }
    }
}
