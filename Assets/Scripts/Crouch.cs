using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class Crouch : MonoBehaviour
{
    CapsuleCollider cap;
    private float originalheight;
    public float reducedheight = 2.5f;
    // Start is called before the first frame update
    void Start()
    {
        cap.GetComponent<CapsuleCollider>();
        originalheight = cap.height;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.V))
        {
            Crouching();
        }
        else if(Input.GetKeyUp(KeyCode.V))
        {
            GetUp();
        }        
    }
    void Crouching()
    {
        cap.height = reducedheight;

    }
    void GetUp()
    {
        cap.height = originalheight;

    }
}
