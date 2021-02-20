using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class switchController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject c1;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.RawButton.Y))
        {
            c1.transform.position += new Vector3(0.5f, 0, 0);
        }
    }
}
