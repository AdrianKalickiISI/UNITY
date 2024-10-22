using UnityEngine;

public class MoveInSquare : MonoBehaviour
{
    public float speed = 5f;
    private int directionIndex = 0;
    private float distanceMoved = 0f;
    private float maxDistance = 10f;

    void Update()
    {
        float moveStep = speed * Time.deltaTime;
        
        
        transform.Translate(Vector3.right * moveStep);
        distanceMoved += moveStep;

        
        if (distanceMoved >= maxDistance)
        {
            distanceMoved = 0f;
            Rotate90Degrees();
        }
    }

    void Rotate90Degrees()
    {
        transform.Rotate(0f, 90f, 0f);
        directionIndex = (directionIndex + 1) % 4; 
    }
}
