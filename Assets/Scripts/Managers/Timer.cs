using UnityEngine.UI;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public Text TimerText;
    private float startTime;
    private bool finished = false;
    PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        startTime = Time.time;
    }

    void Update()
    {
        if (health.currentHealth >= 0) {
        float t = Time.time - startTime;

        string minutes = ((int) t / 60).ToString();
        string seconds = (t % 60).ToString("f2");

        TimerText.text = "SURVIVAL TIME: "+ minutes + " : " + seconds;
        } else {
            return;
        }
    }
}
