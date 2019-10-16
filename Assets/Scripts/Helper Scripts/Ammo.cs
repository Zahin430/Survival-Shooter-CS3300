using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ammo : MonoBehaviour
{
    public static int ammo;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        // ammo = 0;
    }

    void Update ()
    {
        text.text = "Ammo: " + ammo;
    }
}
