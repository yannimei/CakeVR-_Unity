using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sketchSize : MonoBehaviour
{// Start is called before the first frame update
    //public GameObject pic;
    //private GameObject[] pics;
    public Transform point1;
    public Transform point2;
    private float a;
    private Vector3 left, right;
    private float previousDist, currentDist;


    void Start()
    {
        a = 0.01f;
        Vector3 left = point1.position;
        Vector3 right = point2.position;
        previousDist = Vector3.Distance(left, right);
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 left = point1.position;
        Vector3 right = point2.position;


        currentDist = Vector3.Distance(left, right);

        if (currentDist > previousDist)
        {
            for (int i = 0; i < this.transform.childCount; i++) { 
            this.transform.GetChild(i).gameObject.transform.localScale += new Vector3(a * Time.deltaTime, a * Time.deltaTime, a * Time.deltaTime);
            }
        }
        else if (currentDist < previousDist)
        {
            for (int i = 0; i < this.transform.childCount; i++)
            {
                this.transform.GetChild(i).gameObject.transform.localScale -= new Vector3(a * Time.deltaTime, a * Time.deltaTime, a * Time.deltaTime);
            }
        }

        previousDist = currentDist;




    }
}
