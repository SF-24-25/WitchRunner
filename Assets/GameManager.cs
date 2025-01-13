using UnityEngine;
using UnityEngine.SceneManagement;

public class GameMangaer : MonoBehaviour
{
    bool GameHasEnded = false;

    public GameObject completeUI;

    public void Gameover()
    {
        completeUI.SetActive(true);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void EndGame()
    {
        if (GameHasEnded == false)
        {
            GameHasEnded = true;
            // Debug.Log("gamed over");
            Gameover();
            Invoke("Restart", 2f);

        }

    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}