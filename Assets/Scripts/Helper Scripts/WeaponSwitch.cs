using UnityEngine.UI;
using UnityEngine;

public class WeaponSwitch : MonoBehaviour
{
    // Reference to the weaponSwitch
    public int selectedWeapon = 0;

    public static int score;

    Text text;

    void Start()
    {
        SelectWeapon();
    }

    // Update is called once per frame
    void Update()
    {
        // Assigns the gameobject at index 0 as first
        int previousSelectedWeapon = selectedWeapon;

        // Checks MouseScroll and changes the weapon based on the FP Weapon transform
        if(Input.GetAxis("Mouse ScrollWheel") > 0f) 
        {
            if (selectedWeapon >= transform.childCount - 1){
                selectedWeapon = 0;
            } else {
                selectedWeapon++;
            }
        }

        // Checks MouseScroll and changes the weapon based on the FP Weapon transform if scrolled reverse
        if(Input.GetAxis("Mouse ScrollWheel") < 0f) 
        {
            if (selectedWeapon <= 0){
                selectedWeapon = transform.childCount - 1;
            } else {
                selectedWeapon--;
            }
        } 

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedWeapon = 0;
        }


        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 2)
        {
            selectedWeapon = 1;
        }

        if (Input.GetKeyDown(KeyCode.Alpha3) && transform.childCount >= 3)
        {
            selectedWeapon = 2;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2) && transform.childCount >= 4)
        {
            selectedWeapon = 3;
        }
        if (previousSelectedWeapon != selectedWeapon)
        {
            SelectWeapon();
        }  
    }

    // Selects weapon from the transform child object and sets active
    void SelectWeapon()
    {
        text = GetComponent<Text>();
        int i = 0;
        foreach(Transform weapon in transform)
        {
            // Indexing and checking for the selectedWeapon index and sets active
            if (i == selectedWeapon) 
            {
                weapon.gameObject.SetActive(true);
                text.text = "WEAPON: " + weapon.gameObject.name;
            } else {
                weapon.gameObject.SetActive(false);
            }
            i++;
        }
    }
}
