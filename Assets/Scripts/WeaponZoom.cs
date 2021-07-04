using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class WeaponZoom : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] Camera fpsCamera;
    [SerializeField] float zoomedOutFov = 60f;
    [SerializeField] float zoomedInFov = 35f;
    bool zoomedInToggle = false;
    RigidbodyFirstPersonController fpsController;
    [SerializeField] float zoomedOutSensitivity = 2f;
    [SerializeField] float zoomedInSensitivity = 0.5f;
    Weapon weapon;

    private void Start()
    {
        GameObject theweapon = GameObject.Find("Weapon");
        fpsController = GetComponent<RigidbodyFirstPersonController>();
        Weapon weapon = GetComponent<Weapon>();
    }

    private void Update()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(zoomedInToggle == false)
            {
                zoomedInToggle = true;
                fpsCamera.fieldOfView = zoomedInFov;
                fpsController.mouseLook.XSensitivity = zoomedInSensitivity;
                fpsController.mouseLook.YSensitivity = zoomedInSensitivity;
                weapon.range += 30f;
            }
            else
            {
                zoomedInToggle = false;
                fpsCamera.fieldOfView = zoomedOutFov;
                fpsController.mouseLook.XSensitivity = zoomedOutSensitivity;
                fpsController.mouseLook.YSensitivity = zoomedOutSensitivity;
                weapon.range -= 30f;
            }
        }
    }
}
