using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

//using static System.Net.Mime.MediaTypeNames;


public class GroundTile : MonoBehaviour
{
    //public new_score score;
    GroundSpawner groundSpawner;
    private int no_trees = 1;
    //public Text scoreText;         


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        Playerscore playerscore = GameObject.FindAnyObjectByType<Playerscore>();
        groundSpawner = GameObject.FindAnyObjectByType<GroundSpawner>();
        //no_trees = 1;
        //Debug.Log(score.score_combined);
        if (playerscore.score_combined > 100)
        {
            no_trees = Random.Range(1, 3);
        }
        Debug.Log(no_trees);

        for (int i = 0; i < no_trees; i++)
        {
            spawnObstacle();
        }
        SpawnCoins();  
    }

    private void OnTriggerExit(Collider other)
    {
        groundSpawner.SpawnTile();
        Destroy(gameObject, 2);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject obstaclePrefab; 

    void spawnObstacle()
    {
        int obstacleSpawnIndex = Random.Range(2, 9);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;
        Instantiate(obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }

    public GameObject coinPrefab;

    void SpawnCoins()
    {
        int coinsToSpawn = 1;
        for (int i = 0; i < coinsToSpawn; i++)
        {
            GameObject temp = Instantiate(coinPrefab, transform);
            temp.transform.position = GetRandomPointinCollider(GetComponent<Collider>());
        }
    }

    Vector3 GetRandomPointinCollider (Collider collider)
    {
        Vector3 point = new Vector3(
            Random.Range(collider.bounds.min.x, collider.bounds.max.x),
            Random.Range(collider.bounds.min.y, collider.bounds.max.y),
            Random.Range(collider.bounds.min.z, collider.bounds.max.z)
            );
        if( point != collider.ClosestPoint(point))
        {
            point = GetRandomPointinCollider(collider);
        }
        point.y = 0;
        return point;
    }

}
