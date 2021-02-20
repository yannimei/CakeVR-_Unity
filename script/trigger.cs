using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    //public GameObject pic;
    //private GameObject[] pics;
    //public GameObject operation;
   
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
        

        
            if (this.GetComponent<OVRGrabbable>().isGrabbed && this.GetComponent<OVRGrabbable>().grabbedBy == OVRInput.Get(OVRInput.Button.PrimaryHandTrigger) &&
                this.GetComponent<OVRGrabbable>().grabbedBy == OVRInput.Get(OVRInput.Button.SecondaryHandTrigger))
            {
                this.GetComponent<ChangePicSize>().enabled = true;
                
            } else
            {
                this.GetComponent<ChangePicSize>().enabled = false;
            }

        
    }
}

