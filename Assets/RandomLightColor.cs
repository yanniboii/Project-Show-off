using UnityEngine;

public class RandomLightColor : MonoBehaviour
{
    private Light lightComponent;
    private float changeInterval = 1f;
    private float timer = 0f;

    void Start()
    {
        timer = Random.Range(0f, changeInterval);
        // Get the Light component attached to this GameObject
        lightComponent = GetComponent<Light>();

        // Initialize the light color to a random color
        lightComponent.color = GetRandomColor();
    }

    void Update()
    {
        // Increment the timer with the time passed since the last frame
        timer += Time.deltaTime;

        // If the timer exceeds the interval, change the light color
        if (timer >= changeInterval)
        {
            lightComponent.color = GetRandomColor();
            timer = 0f; // Reset the timer
        }
    }

    // Method to get a random color
    Color GetRandomColor()
    {
        return new Color(Random.Range(0f, 1f), Random.Range(0f, 1f), Random.Range(0f, 1f));
    }
}