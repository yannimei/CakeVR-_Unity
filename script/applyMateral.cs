using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class applyMateral : MonoBehaviour

{
    // Start is called before the first frame update
    //public GameObject operation;
    //private int number;
    public Material[] mat;
    private PhotonView photonview;
    private GameObject operation;
    private int colorCode;
    public GameObject cake;
    //public GameObject cake;

    void Start()
    {
        photonview = GetComponent<PhotonView>();
        operation = GameObject.Find("operation");
    }

    // Update is called once per frame
    void Update()
    {

       //if (photonview.IsMine) { 
        if ( cake.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.Get(OVRInput.RawButton.LHandTrigger))
            //if (Input.GetKey("5"))
            {
                colorCode = operation.GetComponent<changeMaterial>().num;
                photonview.RPC("RPC_material", RpcTarget.All, colorCode);
                
            }
            //print(GameObject.Find("operation").GetComponent<changeMaterial>().num);
            //print(this.GetComponent<OVRGrabbable>().grabbedBy == OVRInput.Get(OVRInput.Button.SecondaryHandTrigger));
      //  }
    }


    [PunRPC]
    void RPC_material(int a)
    {
        colorCode = a;
        this.GetComponent<Renderer>().material = mat[colorCode];
        
    }

  

}
