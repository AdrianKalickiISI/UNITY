using UnityEngine;
using System.Collections.Generic;

public class MovingPlatformWithWaypoints : MonoBehaviour
{
    public List<Transform> waypoints = new List<Transform>();  
    public float platformSpeed = 3f;                           

    private int currentWaypointIndex = 0;                      
    private bool movingForward = true;                         

    void Update()
    {
        if (waypoints.Count == 0) return;  

        MovePlatform();                    
    }

    private void MovePlatform()
    {        
        Transform targetWaypoint = waypoints[currentWaypointIndex];

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, platformSpeed * Time.deltaTime);

        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            if (movingForward)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Count)
                {
                    currentWaypointIndex = waypoints.Count - 2;
                    movingForward = false;
                }
            }
            else
            {
                currentWaypointIndex--;
                if (currentWaypointIndex < 0)
                {
                    currentWaypointIndex = 1;
                    movingForward = true;
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.transform.SetParent(transform); 
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) 
        {
            other.transform.SetParent(null); 
        }
    }
}
