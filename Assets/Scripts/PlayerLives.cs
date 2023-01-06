using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Text livesText;
    public LayerMask respawnLayer;


	void Start()
{
    // Update the lives display when the game starts
    UpdateLivesDisplay();
}	

    // Decreases the player's number of lives by 1 and updates the lives display
    public void TakeDamage()
    {
        lives--;
        UpdateLivesDisplay();

        // Check if the player has any lives left
        if (lives <= 0)
        {
            // Player is out of lives, game over
            // Get a reference to the Text component of the game over canvas
Text gameOverText = GameObject.Find("GameOverCanvas/GameOverText").GetComponent<Text>();

// Set the text of the game over message
gameOverText.text = "Game Over!";

// Set the game over canvas to be active
GameObject.Find("GameOverCanvas").SetActive(true);

        }
    }

    // Increases the player's number of lives by 1 and updates the lives display
    public void RestoreLife()
    {
        lives++;
        UpdateLivesDisplay();
    }

    // Updates the lives display to reflect the current number of lives
    private void UpdateLivesDisplay()
    {
		Debug.Log("Updating lives display with value: " + lives);

        string livesString = "";
        for (int i = 0; i < lives; i++)
        {
            livesString += "❤";
        }
        livesText.text = livesString;
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has encountered a trap
        if (other != null && other.gameObject.tag == "Trap")
        {
            // Get a reference to the PlayerLives script attached to the player game object
            PlayerLives playerLives = GetComponent<PlayerLives>();

            // Decrease the number of lives by 1
            playerLives.TakeDamage();
        }
        
        if (other != null && other.gameObject.layer == respawnLayer)
        {
            Debug.Log("Respawn");
            transform.position = new Vector3(0.5f, 13f, 0.5f);
        }
    }
}
