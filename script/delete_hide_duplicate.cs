using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class delete_hide_duplicate : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sth;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       //copy
       
        if (Input.GetKeyDown("c"))
        {
            GameObject sth_clone = Instantiate(sth, sth.transform.position + new Vector3(0.1f, 0f, 0f), sth.transform.rotation );
        }


        //delete
        if (Input.GetKeyDown("d"))
        {
            Destroy(sth);
        }
    }


}
