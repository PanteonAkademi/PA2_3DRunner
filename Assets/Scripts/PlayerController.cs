using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float runningSpeed;
    public float xSpeed;
    public float limitx;

    // Added new codes
    public Animator PlayerAnim;
    public GameObject Player;

    void Start()
    {
        // Added new codes
        PlayerAnim = Player.GetComponentInChildren<Animator>();
    }

    
    void Update()
    {
        SwipeCheck();
    }

    void SwipeCheck()
    {
        float newX = 0;
        float touchXDelta = 0;
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            //Debug.Log(Input.GetTouch(0).deltaPosition.x / Screen.width);
            touchXDelta = Input.GetTouch(0).deltaPosition.x / Screen.width;
        }
        else if (Input.GetMouseButton(0))
        {
            touchXDelta = Input.GetAxis("Mouse X");
        }
        newX = transform.position.x + xSpeed * touchXDelta * Time.deltaTime;
        newX = Mathf.Clamp(newX, -limitx, limitx);

        Vector3 newPosition = new Vector3(newX, transform.position.y, transform.position.z + runningSpeed * Time.deltaTime);
        transform.position = newPosition;
    }
}
