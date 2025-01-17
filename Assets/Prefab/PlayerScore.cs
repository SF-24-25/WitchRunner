using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Playerscore : MonoBehaviour
{
    public Text scoreText;         // Reference to the score UI Text
    public int score_combined=0;    // The player's score
    public int score_distance;    // The player's score
    public int score_coin=0;    // The player's score

    public void OnTriggerEnter(Collider other)
    {
        // Handle coin collection
        if (other.gameObject.CompareTag("coin"))
        {
            score_coin += 5;          // Add points for collecting the coin
            Destroy(other.gameObject);    // Remove the collected 

        }
    }

    public void Update()
    {
        // Update score based on player's z position
        score_distance = Mathf.FloorToInt(transform.position.z + 4);
        score_combined = score_distance + score_coin;
        scoreText.text = score_combined.ToString();

    }


    public void FixedUpdate()
    {
    }

}
