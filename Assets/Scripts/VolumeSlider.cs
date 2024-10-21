using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    public Slider slider;  // Reference to the UI slider
    public MusicManager musicManager;  // Reference to the MusicManager script

    void Start()
    {
        // Initialize the slider value
        slider.onValueChanged.AddListener(SetVolume);  // Add listener to slider's value changes
    }

    // Method that updates the volume based on slider's value
    void SetVolume(float value)
    {
        musicManager.SetVolume(value);  // Call the SetVolume method in the MusicManager script
    }
}
