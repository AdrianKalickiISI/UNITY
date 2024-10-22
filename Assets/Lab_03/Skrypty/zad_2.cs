using UnityEngine;

public class MoveCube : MonoBehaviour
{
    public float speed = 1f;  
    private float direction = 1f;  
    private float movedDistance = 0f;  

    void Update()
    {
        
        float movement = speed * Time.deltaTime * direction;
        transform.Translate(movement, 0, 0);
        
        
        movedDistance += Mathf.Abs(movement);

        
        if (movedDistance >= 10f)
        {
            direction *= -1;  
            movedDistance = 0f;  
        }
    }
}
