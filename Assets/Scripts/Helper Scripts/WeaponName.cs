using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponName : MonoBehaviour
{
    public static new string name;

    Text text;

    void Awake ()
    {
        text = GetComponent <Text> ();
        name = "";
    }

    void Update ()
    {
        text.text = "WEAPON: " + name;
    }
}
