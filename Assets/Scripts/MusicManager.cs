using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioClip backgroundMusic;  // Reference to the background music clip
    private AudioSource audioSource;   // Audio source to play the music

    void Start()
    {
        audioSource = gameObject.AddComponent<AudioSource>();  // Add an AudioSource component to the GameObject
        audioSource.clip = backgroundMusic;  // Set the background music clip
        audioSource.loop = true;  // Set the music to loop
        audioSource.playOnAwake = true;  // Start playing when game starts

        audioSource.Play();  // Play music
    }

    // Method to adjust music volume
    public void SetVolume(float volume)
    {
        audioSource.volume = Mathf.Clamp(volume, 0f, 1f);  // Clamp the volume between 0 and 1
    }
}
