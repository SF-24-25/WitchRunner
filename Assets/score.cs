using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class score : MonoBehaviour
{
    private int score2;
    private float score3;
    public int noCoins;
    public GameObject Coin;
    private Coin coinscript;
    //public Rigidbody player_for_score;
    public Transform player;
    public Text scoreText;
    void Update()
    {
        coinscript = Coin.GetComponent<Coin>();
        score2= coinscript.no_of_coins;
        // Debug.Log(player.position.z);
        score3 = (player.position.z + 2) + score2;
        scoreText.text = score3.ToString("0");
        if (gameObject.CompareTag("obstacle"))
        {
            // Restart the current scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("Hello");
        }
    }
}
