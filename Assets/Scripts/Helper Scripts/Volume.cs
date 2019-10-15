using UnityEngine;

public class Volume: MonoBehaviour {
    //Reference to Audio Source Component
    private AudioSource audioSource;

    // Music volume variable that will be modified if slider dragged
    private float volume = 1f;

    // Use this for initialization
    void Start()
    {
        // Assign Audio Source to control it
        audioSource = GetComponent<AudioSource>();
    }

    // void Awake() {
    //     DontDestroyOnLoad (transform.gameObject);    
    // }
    // Update is called once per frame
    void Update() 
    {
        // Setting volume option of Audio Source to be equal to volume
        audioSource.volume = volume;
    }

    // Method to call the slider gameObject
    // Method takes the vol value passed by the slider
    // and sets it as volumne
    public void setVolume(float vol) 
    {
        volume = vol;
        Persistent.Volume = vol;
    }
}