using UnityEngine;

public class EnemyFloatingText : MonoBehaviour
{
    public float DestroyTime = 3f; // The float destroy time
    public Vector3 Offset = new Vector3(0, 2, 0);   // Offset shown above the enemy
    public Vector3 RandomizeIntensity = new Vector3(0.5f,0,0);  // Randomize intensity to change accordingly

    void Start()
    {
        // Destroy the gameObject attached 
        Destroy(gameObject, DestroyTime);
        // Change the transform's position
        transform.localPosition += Offset;
        // Randomize the Intensity for Vector3 in x, y and z axis
        transform.localPosition += new Vector3(Random.Range(-RandomizeIntensity.x, RandomizeIntensity.x),
        Random.Range(-RandomizeIntensity.y, RandomizeIntensity.y),
        Random.Range(-RandomizeIntensity.z, RandomizeIntensity.z) 
        );
    }

}
