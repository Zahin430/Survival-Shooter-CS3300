using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

using UnityEngine;

public class KillManager : MonoBehaviour
{
    public static int death;
    Text text;


    void Awake ()
    {
        text = GetComponent <Text> ();
        death = 0;
    }


    void Update ()
    {
        text.text = "Killed: " + death;
    }
}
