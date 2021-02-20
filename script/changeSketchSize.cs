using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class changeSketchSize : MonoBehaviour
{
    public GameObject bigParent;
   
    private int  b, k;
    private int[] a;
    private bool[] ok;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        b = bigParent.transform.childCount;
        a = new int[b];
        ok = new bool[b];

        for (int i = 0; i < b; i++)
        {
            a[i] = 0;
            ok[i] = false;
        }

        for (int i = 0; i < b; i++)
        {
            GameObject sketch = bigParent.transform.GetChild(i).gameObject;
            
            for (int j = 0; j < sketch.transform.childCount; j++)
            {
                GameObject stroke = sketch.transform.GetChild(j).gameObject;
                if (stroke.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.Get(OVRInput.RawButton.LHandTrigger) && OVRInput.Get(OVRInput.RawButton.RHandTrigger))
                {
                    a[i] += 1;
                }

            }

            if (a[i] >= 1)
            {
                ok [i] = true;
                //k = i;  
            }

        }

        for (int i = 0; i < b; i++)
        {
            if (ok[i])
            {
                bigParent.transform.GetChild(i).gameObject.GetComponent<sketchSize>().enabled = true;
            }
            else
            {
                bigParent.transform.GetChild(i).gameObject.GetComponent<sketchSize>().enabled = false;
            }

        }





    }

}
