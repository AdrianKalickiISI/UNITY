using UnityEngine;
using System.Collections.Generic;

public class CubeGenerator : MonoBehaviour
{
    public GameObject cubePrefab; 
    public int numberOfCubes = 10; 
    public float planeSize = 10f;  
    
    private HashSet<Vector3> usedPositions = new HashSet<Vector3>(); 

    void Start()
    {
        GenerateCubes();
    }

    void GenerateCubes()
    {
        for (int i = 0; i < numberOfCubes; i++)
        {
            Vector3 randomPosition = GetRandomPosition();

            
            Instantiate(cubePrefab, randomPosition, Quaternion.identity);
        }
    }

    Vector3 GetRandomPosition()
    {
        Vector3 randomPosition;
        do
        {
            
            float x = Random.Range(-planeSize / 2, planeSize / 2);
            float z = Random.Range(-planeSize / 2, planeSize / 2);
            randomPosition = new Vector3(Mathf.Round(x), 0.5f, Mathf.Round(z)); 
        } while (usedPositions.Contains(randomPosition)); 

        usedPositions.Add(randomPosition); 
        return randomPosition;
    }
}
