using UnityEngine;
using UnityEngine.UI;

public class Playerscore : MonoBehaviour
{
    public Text scoreText;          // Reference to the score UI Text
    public Text AddOn_Plus_Five;    // Reference to the "+5" text
    public int score_combined = 0;  // The player's combined score
    public int score_distance;      // The player's distance score
    public int score_coin = 0;      // The player's coin score

    private void OnTriggerEnter(Collider other)
    {
        // Handle coin collection
        if (other.gameObject.CompareTag("coin"))
        {
            score_coin += 5;           // Add points for collecting the coin
            Destroy(other.gameObject);   // Remove the collected coin
            Debug.Log("Coin collected!");
            AddOn_Plus_Five.text ="+" + (int.Parse(AddOn_Plus_Five.text) + 5).ToString();
            StartCoroutine(ShowAddOnText()); // Start the coroutine to show "+5"
        }
    }

    private System.Collections.IEnumerator ShowAddOnText()
    {
        AddOn_Plus_Five.gameObject.SetActive(true); // Enable the "+5" text
        yield return new WaitForSeconds(0.5f);        // Wait for 1 second
        AddOn_Plus_Five.gameObject.SetActive(false); // Disable the "+5" text
        AddOn_Plus_Five.text = "0";
    }

    private void Update()
    {
        // Update score based on player's z position
        score_distance = Mathf.FloorToInt(transform.position.z + 4);
        score_combined = score_distance + score_coin;
        scoreText.text = score_combined.ToString();
    }
}
