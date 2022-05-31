using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//Yara Ayman Abd El-Kader
//17101960

public class PlayerScript : MonoBehaviour
{
    private int scoreCounter;
    public Text scoreText;
    public Text healthText;
    private int healthCounter = 100;
    public GameObject Gate1;
    public GameObject Gate2;
    public GameObject Gate3;
    public GameObject Gate4;
    public GameObject Level2;
    public GameObject Level1;

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3();
        movement.x = moveHorizontal;
        movement.z = moveVertical;

        Rigidbody rb = this.GetComponent<Rigidbody>();
        rb.AddForce(movement*500*Time.deltaTime);

        if(scoreCounter == 3 )
        {
            Gate1.gameObject.SetActive(false);
        }

        if (scoreCounter == 6)
        {
            Gate2.gameObject.SetActive(false);
        }

        if (scoreCounter == 12)
        {
            Gate3.gameObject.SetActive(false);
        }

        if (scoreCounter == 15)
        {
            Gate4.gameObject.SetActive(false);
        }

    }

    void OnTriggerEnter (Collider x)
    {
        if (x.tag == "Pickup")
        {
            x.gameObject.SetActive(false);
            scoreCounter++;
            scoreText.text = "Score: " + scoreCounter;

          

            if (scoreCounter == 9)
            {
                Level2.gameObject.SetActive(true);
                Level1.gameObject.SetActive(false);
            }
            else if(scoreCounter == 18)
            {
                scoreText.text = "YOU WIN!!!";
                scoreText.color = Color.yellow;
            }
        }
        if (x.tag == "Avoid")
        {
            x.gameObject.SetActive(false);
            healthCounter = healthCounter - 40;
            healthText.text = "Health: " + healthCounter;

            if(healthCounter <= 0)
            {
                healthText.text = "YOU LOSE!";
                healthText.color = Color.red;
            }

        }
        
    }

}
