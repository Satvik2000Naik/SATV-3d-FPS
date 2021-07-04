using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{
    // Start is called before the first frame update
    private LineRenderer lr;
    private Vector3 grapplePoint;
    public LayerMask whatisgrappable;
    public Transform guntip , camera ,player;
    [SerializeField] float maxDistance = 7000f;
    private SpringJoint joint;
    [SerializeField] AudioClip websling;
    AudioSource audii;

    private void Start()
    {
        audii = GetComponent<AudioSource>();
    }

    void Awake()
    {
        lr = GetComponent<LineRenderer>();
    }
    void Update()
    {
      
       if(Input.GetMouseButtonDown(0))
        {
            //grapple
            StartGrapple();
            audii.PlayOneShot(websling);
            

        }
       else if(Input.GetMouseButtonUp(0))
        {
            stopGrappling();
            audii.Stop();
        }
    }

     void stopGrappling()
    {
        //throw new NotImplementedException();
        lr.positionCount = 0;
        Destroy(joint);

    }

    private void LateUpdate()
    {
        DrawRope();
    }

    void StartGrapple()
    {
        // throw new NotImplementedException();
        RaycastHit hit;
        if(Physics.Raycast(camera.position , camera.forward , out hit , maxDistance))
        {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFrompoint = Vector3.Distance(player.position , grapplePoint);
            joint.maxDistance = distanceFrompoint * 1f;
            joint.minDistance = distanceFrompoint * 0.35f;

            joint.spring = 4.5f;
            joint.damper = 18f;
            joint.massScale = 4.5f;


            lr.positionCount = 2;
                





        }
    }
    void DrawRope()
    {
        //if no grapple dont draw
        if (!joint) return;
        lr.SetPosition(0, guntip.position);
        lr.SetPosition(1, grapplePoint);
    }

    public bool IsGrappling()
    {
        return joint != null;
    }

    public Vector3 GetGrapplePoint()
    {
        return grapplePoint;
    }
}
