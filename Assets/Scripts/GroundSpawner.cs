using UnityEngine;

public class GroundSpawner : MonoBehaviour
{
    public GameObject groundTile;
    Vector3 nextSpawnPoint;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    
    public void SpawnTile()
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;
    }
    
    void Start()
    {
        for(int i = 0; i < 15; i++)
        {
            SpawnTile();   
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
