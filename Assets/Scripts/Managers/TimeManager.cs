
using UnityEngine.UI;

using UnityEngine;

public class TimeManager : MonoBehaviour
{
    Text text;
    public float theTime;
    public float speed = 1;
    private float startTime;
    private bool finished = false;
    public PlayerHealth health;
    
    // Start is called before the first frame update
    void Start()
    {
        health = GetComponent<PlayerHealth>();
        text = GetComponent <Text> ();
        startTime = Time.time;
    }
    void Update()
    {
        if(health.currentHealth >= 0) {
            theTime += Time.deltaTime * speed;
            string hours = Mathf.Floor((theTime % 210000) / 3000).ToString("00");
            string minutes = Mathf.Floor((theTime % 3600)/60).ToString("00");
            string seconds = (theTime % 60).ToString("00");
        text.text = hours + ":" +minutes + ":" + seconds;
        }
        // float t = Time.time - startTime;

        // string minutes = ((int) t / 60).ToString();
        // string seconds = (t % 60).ToString("f2");
        // string hours = ()

    }
}
