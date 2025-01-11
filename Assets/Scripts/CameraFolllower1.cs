using UnityEngine;



public class CameraFolllower1 : MonoBehaviour
{
    public Transform player;
    Vector3 offset;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        offset = transform.position- player.position;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPos = player.position + offset;
        targetPos.x= offset.x;
        transform.position = targetPos;
    }
}
