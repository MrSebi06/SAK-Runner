using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Text livesText;


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
        if (lives <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("GameOver");
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
    }
}
