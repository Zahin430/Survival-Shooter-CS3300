using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TimerText;  // Timer Text to keep a reference of the gameobject 
    private float StartTime; // startTime to keep a reference of Time at start
    private bool keepTiming = false; // a boolean to stop time upon end of scene
    PlayerHealth health; // Reference to the health of the

    void Start()
    {
        health = GetComponent<PlayerHealth>();
        // startTime = Time.time;
        StartTimer();
    }

    void Update()
    {
        if (health.currentHealth <= 0)
        {
            StopTimer();
        }

        if (keepTiming)
        {
            UpdateTime();
        }
    }

    void StartTimer()
    {
        keepTiming = true;
        StartTime = Time.time;
    }
    void StopTimer()
    {
        keepTiming = false;
    }
    void UpdateTime()
    {
        float t = Time.time - StartTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        TimerText.text = "SURVIVAL TIME: "+ minutes + " : " + seconds;
    }
}
