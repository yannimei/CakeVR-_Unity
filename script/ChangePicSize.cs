using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangePicSize : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject pic;
    //private GameObject[] pics;
    //public Transform point1;
    //public Transform point2;
    public float a;
    private Vector3 left, right;
    private float previousDist, currentDist;


    void Start()
    {
        a = 0.2f;
        Vector3 left = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").transform.position;
        Vector3 right = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor").transform.position;
        previousDist = Vector3.Distance(left, right);
    }

    // Update is called once per frame
    void Update()
    {

            Vector3 left = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").transform.position;
            Vector3 right = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor").transform.position;


            currentDist = Vector3.Distance(left, right);

            if (currentDist > previousDist)
            {
                this.transform.localScale += new Vector3(a*Time.deltaTime, a*Time.deltaTime, a * Time.deltaTime);
            } else if (currentDist < previousDist)
            {
            this.transform.localScale -= new Vector3(a*Time.deltaTime, a*Time.deltaTime, a * Time.deltaTime);
            }

            previousDist = currentDist;
            

            //if (pic.GetComponent<OVRGrabbable>().isGrabbed && pic.GetComponent<OVRGrabbable>().grabbedBy == leftGrabber && pic.GetComponent<OVRGrabbable>().grabbedBy == rightGrabber)
            //{
            //    Vector3 left = point1.transform.position;
            //    Vector3 right = point2.transform.position;

            //    previousDist = Vector3.Distance(left, right);
            //    currentDist = Vector3.Distance(left, right);

            //    if (currentDist > previousDist)
            //    {
            //        pic.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, 0);
            //    }
            //    else if (currentDist < previousDist)
            //    {
            //        pic.transform.localScale -= new Vector3(Time.deltaTime, Time.deltaTime, 0);
            //    }

            //    previousDist = currentDist;
            //    currentDist = Vector3.Distance(left, right);
            


       
    }
}
