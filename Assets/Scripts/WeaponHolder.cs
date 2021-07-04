using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHolder : MonoBehaviour
{
    // Start is called before the first frame update

    public int selectedWeapon = 0;
    void Start()
    {
        SelectWeapon();
    }

    private void SelectWeapon()
    {
        //throw new NotImplementedException();

        int i = 0;
        foreach(Transform Weapon in transform)
        {
            if(i==selectedWeapon)
            {
                Weapon.gameObject.SetActive(true);
            }
            else
            {
                Weapon.gameObject.SetActive(false);
            }
            i++;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        int previousSelectedWeapon = selectedWeapon;
        if(Input.GetAxis("Mouse ScrollWheel") > 0f)
        {
            if (selectedWeapon >= transform.childCount - 1)
                selectedWeapon = 0;
            else
                selectedWeapon++;
        }

        if (Input.GetAxis("Mouse ScrollWheel") < 0f)
        {
            if (selectedWeapon <= 0)
                selectedWeapon = transform.childCount - 1;  
            else
                selectedWeapon--;
        }

        if(previousSelectedWeapon!= selectedWeapon)
        {
            SelectWeapon();
        }
    }
}
