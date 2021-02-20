using Photon.Pun;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetworkPlayer : MonoBehaviour
{
    public GameObject avatar;
    public Transform playerGlobal;
    public Transform playerLocal;

    public int index = 1;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log ("I pop up");

       if (GetComponent<PhotonView>().IsMine)
       {
            switch (index)
            {
                case 1:
                    playerGlobal = GameObject.Find("OVRPlayerController").transform;
                    playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/CenterEyeAnchor");
                    this.transform.SetParent(playerLocal);
                    this.transform.localPosition = Vector3.zero;
                    
                    break;

                case 2:
                    playerGlobal = GameObject.Find("OVRPlayerController").transform;
                    playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor");
                    this.transform.SetParent(playerLocal);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localRotation = Quaternion.Euler(0, 0, 90);
                    break;

                case 3:
                    playerGlobal = GameObject.Find("OVRPlayerController").transform;
                    playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");
                    this.transform.SetParent(playerLocal);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localRotation = Quaternion.Euler(0, 0, -90);
                    break;

                case 4:
                    playerGlobal = GameObject.Find("OVRPlayerController").transform;
                    playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/LeftHandAnchor");
                    this.transform.SetParent(playerLocal);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;

                case 5:
                    playerGlobal = GameObject.Find("OVRPlayerController").transform;
                    playerLocal = playerGlobal.Find("OVRCameraRig/TrackingSpace/RightHandAnchor");
                    this.transform.SetParent(playerLocal);
                    this.transform.localPosition = Vector3.zero;
                    this.transform.localRotation = Quaternion.Euler(0, 0, 0);
                    break;
            }
       }
        
    }

    // Update is called once per frame

    //void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{
    //    if (stream.IsWriting)
    //    {
    //        stream.SendNext(playerGlobal.position);
    //        stream.SendNext(playerGlobal.rotation);
    //        stream.SendNext(playerLocal.localPosition);
    //        stream.SendNext(playerLocal.localRotation);
    //    }
    //    else
    //    {
    //        this.transform.position = (Vector3)stream.ReceiveNext();
    //        this.transform.rotation = (Quaternion)stream.ReceiveNext();
    //        avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
    //        avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
    //    }
    //}

    void Update()
    {
        
    }
}
