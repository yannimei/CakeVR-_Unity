using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class stroke : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]private GameObject brush;
   
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        brush = this.GetComponent<draw>().brushs;



        if (OVRInput.Get(OVRInput.RawButton.LThumbstickDown) && brush.transform.localScale.x >= 0.005)
        {
            brush.transform.localScale -= new Vector3(0.001f, 0.001f, 0.001f);
        }
        
        if (OVRInput.Get(OVRInput.RawButton.LThumbstickUp) && brush.transform.localScale.x <= 0.1)
        {
            brush.transform.localScale += new Vector3(0.002f, 0.002f, 0.002f);
        }
    }
}
