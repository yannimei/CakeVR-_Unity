using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class changeSizeHorizon : MonoBehaviour
{
    public GameObject cake;
    public GameObject left, right,up,follow;
    public GameObject leftS, rightS, upS;
    public float a, b, c, d;
    private Vector3 lastPosLeft, lastPosRight, lastPosUp;
    private Vector3 currentPosLeft, currentPosRight, currentPosUp;
    
  

    
    // Start is called before the first frame update
    void Start()
    {
        //start position
        //follow.transform.position = cake.transform.position;
        //left.transform.position = cake.transform.position + new Vector3(-0.15f, 0, 0);
        //right.transform.position = cake.transform.position + new Vector3(0.15f, 0, 0);

        //record last moment

        follow.transform.position = cake.transform.position;
        follow.transform.rotation = cake.transform.rotation;

        lastPosLeft = left.transform.localPosition;
        lastPosRight = right.transform.localPosition;
        lastPosUp = up.transform.localPosition;



    }

    // Update is called once per frame
    void Update()
    {


        follow.transform.position = cake.transform.position;
        follow.transform.rotation = cake.transform.rotation;




        currentPosRight.x = right.transform.localPosition.x;
        currentPosLeft.x = -currentPosRight.x;
        currentPosUp.y = up.transform.localPosition.y;
       

        left.transform.localPosition = new Vector3 (currentPosLeft.x, 0.01f, 0);
        right.transform.localPosition = new Vector3 (currentPosRight.x, 0.01f, 0);
        up.transform.localPosition = new Vector3(0, currentPosUp.y, 0);



        if (right.GetComponent<OVRGrabbable>().isGrabbed){ 
            if (currentPosRight.x > lastPosRight.x)
            {
                cake.transform.localScale += new Vector3(a * Time.deltaTime,0 , a * Time.deltaTime);
            }
            else if (currentPosRight.x < lastPosRight.x )
            {
                cake.transform.localScale -= new Vector3(b * Time.deltaTime, 0, b * Time.deltaTime);
            }
        }

        if (up.GetComponent<OVRGrabbable>().isGrabbed)
        {
            if (currentPosUp.y > lastPosUp.y)
            {
                cake.transform.localScale += new Vector3(0, c * Time.deltaTime, 0);
            }
            else if (currentPosUp.y < lastPosUp.y)
            {
                cake.transform.localScale -= new Vector3(0, d * Time.deltaTime, 0);
            }
        }



        lastPosRight = currentPosRight;
        lastPosLeft = currentPosLeft;
        lastPosUp = currentPosUp;





        if (cake.GetComponent<OVRGrabbable>().isGrabbed && OVRInput.GetDown(OVRInput.RawButton.RThumbstick))
        {
            if (leftS.transform.localScale != Vector3.zero)
            {
                leftS.transform.localScale = Vector3.zero;
                rightS.transform.localScale = Vector3.zero;
                upS.transform.localScale = Vector3.zero;


            }
            else
            {
                leftS.transform.localScale = new Vector3(1, 1, 1);
                rightS.transform.localScale = new Vector3(1, 1, 1);
                upS.transform.localScale = new Vector3(1, 1, 1);


            }
        }

    }
    
}
