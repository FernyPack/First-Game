using UnityEngine;
using UnityEngine.SceneManagement;  // Include the SceneManager namespace

public class SceneManagerScript : MonoBehaviour
{
    // Method to load the game scene
    private void LoadGameScene()
    {
        SceneManager.LoadScene("Game"); // Replace with your actual game scene name
    }
    // Method to load the Main Menu
    public void LoadMainMenu()
    {
        if (Input.GetMouseButtonDown(0))  // 0 refers to the left mouse button
        {
            // Load the game scene when the mouse is clicked
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Method to load the Win scene
    public void LoadWinScene()
    {
        if (Input.GetMouseButtonDown(0))  // 0 refers to the left mouse button
        {
            // Load the game scene when the mouse is clicked
            SceneManager.LoadScene("MainMenu");
        }
    }

    // Method to load the Lose scene
    public void LoadLoseScene()
    {
        if (Input.GetMouseButtonDown(0))  // 0 refers to the left mouse button
        {
            // Load the game scene when the mouse is clicked
            SceneManager.LoadScene("MainMenu");
        }
    }

    void Update()
    {
        // Check if the player clicks the mouse anywhere on the screen
        if (Input.GetMouseButtonDown(0))  // 0 refers to the left mouse button
        {
            // Load the game scene when the mouse is clicked
            LoadGameScene(); // Call a method to load the game scene
        }
    }
}
