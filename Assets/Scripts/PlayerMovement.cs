using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class PlayerMovement : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    bool alive = true;

    public Button LeftButton;  // Assign via Inspector
    public Button RightButton; // Assign via Inspector

    private float speed = 5f; // Initial speed
    public Rigidbody rb;
    float horizontalInput=0f;
    float horizontalInput2 = 0f;
    public float horizontalMultiplier;
    public float minX = -2.5f; // Minimum x position
    public float maxX = 2.5f;  // Maximum x position

    private bool isLeftPressed = false;  // Tracks if LeftButton is pressed
    private bool isRightPressed = false;
    private float smoothTime = 0.1f; // Time to smoothly transition to 0
    private float smoothVelocity = 0f;

    public float speedIncreaseRate = 20f; // Speed increase rate per second

    void Start()
    {
        // Add PointerDown and PointerUp events for LeftButton
        AddEventListeners(LeftButton, () => isLeftPressed = true, () => isLeftPressed = false);

        // Add PointerDown and PointerUp events for RightButton
        AddEventListeners(RightButton, () => isRightPressed = true, () => isRightPressed = false);
    }

    void Update()
    {
        // Update horizontalInput based on button states
        if (isLeftPressed)
            horizontalInput -= 0.1f;
        if (isRightPressed)
            horizontalInput += 0.1f;
        if(!isRightPressed && !isLeftPressed)
            horizontalInput = Mathf.SmoothDamp(horizontalInput, 0f, ref smoothVelocity, smoothTime);

        horizontalInput = Mathf.Clamp(horizontalInput, -1, 1);
        horizontalInput2 = Input.GetAxis("Horizontal");
        // Use the horizontalInput value for 
    }

    private void FixedUpdate()
    {
        if (!alive)
        {
            return;
        }
        // Increase speed over time
        speed += speedIncreaseRate/20f ;

        // Calculate movement
        Vector3 forwardMove = speed * Time.fixedDeltaTime * transform.forward;
        Vector3 horizontalMove = (horizontalInput+horizontalInput2) * horizontalMultiplier * speed * Time.fixedDeltaTime * transform.right;

        // Combine forward and horizontal movement
        Vector3 newPosition = rb.position + forwardMove + horizontalMove;

        // Clamp the x position
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);

        // Apply the clamped position
        rb.MovePosition(newPosition);

        // Visual rotation based on horizontal input
        if (horizontalInput != 0 || horizontalInput2!=0 )
        {
            rb.rotation = Quaternion.Euler(0, 0, -(horizontalInput+horizontalInput2) * 30);
        }
        if(horizontalInput == 0 && horizontalInput2 == 0)
        {
            rb.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    //private void Update()
    //{
    //    // Get horizontal input
    //    horizontalInput = Input.GetAxis("Horizontal");
    //}
    //private void OnLeftButtonPressed()
    //{
    //    isLeftPressed = true;
    //    isRightPressed = false; // Reset RightButton state when LeftButton is pressed
    //}

    //// Handle Right Button press
    //private void OnRightButtonPressed()
    //{
    //    isRightPressed = true;
    //    isLeftPressed = false; // Reset LeftButton state when RightButton is pressed
    //}
    private void AddEventListeners(Button button, UnityEngine.Events.UnityAction onPointerDown, UnityEngine.Events.UnityAction onPointerUp)
    {
        // Add event trigger for PointerDown
        EventTrigger trigger = button.gameObject.AddComponent<EventTrigger>();

        // Add PointerDown Event
        EventTrigger.Entry pointerDownEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerDown
        };
        pointerDownEntry.callback.AddListener((data) => onPointerDown());
        trigger.triggers.Add(pointerDownEntry);

        // Add PointerUp Event
        EventTrigger.Entry pointerUpEntry = new EventTrigger.Entry
        {
            eventID = EventTriggerType.PointerUp
        };
        pointerUpEntry.callback.AddListener((data) => onPointerUp());
        trigger.triggers.Add(pointerUpEntry);
    }
    public void Swipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch t = Input.GetTouch(0);
            if (t.phase == TouchPhase.Began)
            {
                //save began touch 2d point
                firstPressPos = new Vector2(t.position.x, t.position.y);
            }
            if (t.phase == TouchPhase.Ended)
            {
                //save ended touch 2d point
                secondPressPos = new Vector2(t.position.x, t.position.y);

                //create vector from the two points
                currentSwipe = new Vector3(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

                //normalize the 2d vector
                currentSwipe.Normalize();

                //swipe upwards
                if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
		     {
                    Debug.Log("up swipe");
                }
                //swipe down
                if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
		     {
                    Debug.Log("down swipe");
                }
                //swipe left
                if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		     {
                    Debug.Log("left swipe");
                    Vector3 newposition2 = new Vector3(0, 0, -2);
                    rb.MovePosition(newposition2);
                }
                //swipe right
                if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
		     {
                    Debug.Log("right swipe");
                    Vector3 newposition2 = new Vector3(0, 0, 2);
                    rb.MovePosition(newposition2);
                }
            }
        }
    }
}
