using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    public Transform Target;
    public float MinModifier;
    public float MaxModifier;
    Vector3 _velocity = Vector3.zero;
    bool _isFollowing = false;
    public Weapon weapon;
    public int AmmoLoot = 5;


    void Start()
    {
        // weapon = gameObject.GetComponent<Weapon>();    
    }

    public void StartFollowing()
    {
        _isFollowing = true;
        // weapon.currentAmmo += 1;
        // if (weapon.currentAmmo == 40) 
        // {
        //     Debug.Log(weapon.currentAmmo);
        // }
    }

    // Update is called once per frame
    void Update()
    {
        if (_isFollowing)
        {
            // Starts running right from the beginning...
            transform.position = Vector3.SmoothDamp(transform.position, Target.position, ref _velocity, Time.deltaTime * Random.Range(MinModifier, MaxModifier));

        }
    }
}
