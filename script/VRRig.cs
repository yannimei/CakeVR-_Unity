using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;



//switch (a)
//{
//    case 1:
//        rigTarget.position = oculusManager.instance.head.transform.TransformPoint(positionOffset);
//        rigTarget.rotation = oculusManager.instance.head.transform.rotation * Quaternion.Euler(rotationOffset);
//        break;
//    case 2:
//        rigTarget.position = oculusManager.instance.lhand.transform.TransformPoint(positionOffset);
//        rigTarget.rotation = oculusManager.instance.lhand.transform.rotation * Quaternion.Euler(rotationOffset);
//        break;
//    case 3:
//        rigTarget.position = oculusManager.instance.rhand.transform.TransformPoint(positionOffset);
//        rigTarget.rotation = oculusManager.instance.rhand.transform.rotation * Quaternion.Euler(rotationOffset);
//        break;

//}
[System.Serializable]
public class VRMap
{
    //public Transform vrTarget;
    public Transform rigTarget;
    public GameObject body;
    public Vector3 positionOffset;
    public Vector3 rotationOffset;

    //public void map()
    //{
    //    rigTarget.position = vrTarget.TransformPoint(positionOffset);
    //    rigTarget.rotation = vrTarget.rotation * Quaternion.Euler(rotationOffset);
    //}


    public void mapOn(int a)
    {
       if (body.GetComponent<PhotonView>().IsMine)
       {
            switch (a)
            {
                case 1:
                    rigTarget.position = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform.TransformPoint(positionOffset);
                    rigTarget.rotation = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/CenterEyeAnchor").transform.rotation * Quaternion.Euler(rotationOffset);
                    break;
                case 2:
                    rigTarget.position = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").transform.TransformPoint(positionOffset);
                    rigTarget.rotation = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/LeftHandAnchor").transform.rotation * Quaternion.Euler(rotationOffset);
                    break;
                case 3:
                    rigTarget.position = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor").transform.TransformPoint(positionOffset);
                    rigTarget.rotation = GameObject.Find("OVRPlayerController/OVRCameraRig/TrackingSpace/RightHandAnchor").transform.rotation * Quaternion.Euler(rotationOffset);
                    break;
                    
            }
        }
    }
}
    




public class VRRig : MonoBehaviour
{
    public VRMap head;
    public VRMap left;
    public VRMap right;
    
  
    // Start is called before the first frame update
    public Transform headConstraint;
    public Vector3 headBodyOffset;
    public float turnSmoothness;
    void Start()
    {
        headBodyOffset = transform.position - headConstraint.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //transform.position = headConstraint.position + headBodyOffset;
       // transform.forward = Vector3.Lerp(transform.forward, Vector3.ProjectOnPlane(headConstraint.up, Vector3.up).normalized, Time.deltaTime * turnSmoothness);

       
            head.mapOn(1);
            left.mapOn(2);
            right.mapOn(3);
        

        //head.map();
        //left.map();
        //right.map();

    }


   

    
}

