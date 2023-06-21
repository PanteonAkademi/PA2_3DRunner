using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CheckCollisions : MonoBehaviour
{
    public int score;
    public TextMeshProUGUI CoinText;

    // Added new codes
    public PlayerController playerController;
    Vector3 PlayerStartPos;
    public GameObject speedBoosterIcon;


    private void Start()
    {
        PlayerStartPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        speedBoosterIcon.SetActive(false);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Coin"))
        {
            //Debug.Log("Coin collected!..");
            AddCoin();
            //Destroy(other.gameObject);
            other.gameObject.SetActive(false);
        }
        else if (other.CompareTag("Finish"))
        {
            PlayerFinished();
        }
    }

    void PlayerFinished() {
        playerController.runningSpeed = 0f;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            //Debug.Log("Touched Obstacle!..");
            // Added new codes
            transform.position = PlayerStartPos;
        }
    }

    public void AddCoin()
    {
        score++;
        CoinText.text = "Score: " + score.ToString();
    }
}
