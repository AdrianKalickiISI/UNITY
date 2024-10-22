using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class RandomCubesGenerator : MonoBehaviour
{
    public List<Material> materials = new List<Material>(); 
    public GameObject block; 
    public int iloscObiektow = 10; 
    public float delay = 3.0f;
    private List<Vector3> positions = new List<Vector3>(); 

    void Start()
    {
        
        Vector3 basePosition = transform.position;
        
        
        List<int> pozycje_x = new List<int>(Enumerable.Range(0, 20).OrderBy(x => System.Guid.NewGuid()).Take(iloscObiektow));
        List<int> pozycje_z = new List<int>(Enumerable.Range(0, 20).OrderBy(x => System.Guid.NewGuid()).Take(iloscObiektow));

        for (int i = 0; i < iloscObiektow; i++)
        {
            positions.Add(new Vector3(basePosition.x + pozycje_x[i], basePosition.y + 5, basePosition.z + pozycje_z[i]));
        }

        
        StartCoroutine(GenerujObiekt());
    }

    IEnumerator GenerujObiekt()
    {
        foreach (Vector3 pos in positions)
        {
            
            GameObject newBlock = Instantiate(block, pos, Quaternion.identity);

            
            Renderer renderer = newBlock.GetComponent<Renderer>();
            renderer.material = materials[Random.Range(0, materials.Count)];

            
            yield return new WaitForSeconds(delay);
        }
    }
}
