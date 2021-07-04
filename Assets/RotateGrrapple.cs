using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateGrrapple : MonoBehaviour
{
    public Grappling grapplingun;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!grapplingun.IsGrappling())
        {
            return;
            transform.LookAt(grapplingun.GetGrapplePoint());
        }
    }
}
