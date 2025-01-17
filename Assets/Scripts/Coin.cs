using UnityEngine;

public class Coin : MonoBehaviour
{
    public int no_of_coins = 0;
    //public int CoinScore=0;
    public float turnSpeed = 90f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created

    private void OnTriggerEnter(Collider other)
    {

        if (other.gameObject.GetComponent<Obstacle>() != null)
        {
            Destroy(gameObject);
            return;
        }
        if (other.gameObject.name!= "Player")
        {
            return;
        }

        no_of_coins += 5;

        Destroy(gameObject);  
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0,0,turnSpeed*Time.deltaTime);
    }
}
