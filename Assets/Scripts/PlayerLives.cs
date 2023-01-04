using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerLives : MonoBehaviour
{
    public int lives = 3;
    public Text livesText;

    void Update()
    {
        OnTriggerEnter(null);
    }

    private void OnTriggerEnter(Collider other)
    {
        // Check if the player has encountered a trap
        if (other != null && other.gameObject.tag == "Trap")
        {
            // Decrease the number of lives by 1
            lives -= 1;
        }

        // Update the lives display
        string livesString = "";
        for (int i = 0; i < lives; i++)
        {
            livesString += "❤";
        }
        livesText.text = livesString;

        // Check if the player has any lives left
        if (lives <= 0)
        {
            // Player is out of lives, game over
            Debug.Log("Game Over!");
        }
    }
}

