using UnityEngine;
using UnityEngine.SceneManagement;

public class player_collision : MonoBehaviour
{

    public PlayerMovement movement;
    //void OnTriggerEnter(Collision collision)
    //{
    //    //if (collisionInfo.collider.CompareTag("obstacle"))
    //    //{
    //    //    movement.enabled = false;
    //    //    Debug.Log("Hello");
    //    //    //GameMangaer gameManager = Object.FindFirstObjectByType<GameMangaer>();
    //    //    //if (gameManager != null)
    //    //    //{
    //    //    //    gameManager.EndGame();
    //    //    //}
    //    //    //else
    //    //    //{
    //    //    //    Debug.LogError("GameManager not found!");
    //    //    //}
    //    //}
    //    if (collision.gameObject.CompareTag("obstacle"))
    //    {
    //        // Restart the current scene
    //        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //        Debug.Log("Hello");
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collided object has the tag "Obstacle"
        if (other.CompareTag("obstacle"))
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
    }
}