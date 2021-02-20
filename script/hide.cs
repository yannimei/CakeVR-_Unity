using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class hide : MonoBehaviour
{
    public GameObject cafe;
    public GameObject screen;
    public GameObject tool;
    //public Material[] mat;
    private Skybox sky;
    public OVRCameraRig rig;
    public GameObject plane;
    //public bool a = true;
    // Start is called before the first frame update

    //void Start()
    //{

    //    sky = GetComponent<Skybox>();
    //}

    // Update is called once per frame
    // void Update()
    // {

    //  cafe.SetActive(a);



    // if (Input.GetKeyDown("9"))
    // {
    //     sky.material = mat[2];

    //  }

    // }

     

    public void hideScene ()
    {
        //cafe = GameObject.Find("scene");
        // sky = GetComponent<Skybox>();
       if (cafe.activeSelf == true) { 
            cafe.SetActive(false);
            plane.SetActive(true);
        rig.centerEyeAnchor.GetComponent<Skybox>().enabled = true;
       

    } else
       {
          cafe.SetActive(true);
          plane.SetActive(false);
          rig.centerEyeAnchor.GetComponent<Skybox>().enabled = false;
        }

    }

    public void hideScreen()
    {
        //cafe = GameObject.Find("scene");
        // sky = GetComponent<Skybox>();
        if (screen.activeSelf == true)
        {
            screen.SetActive(false);


        }
        else
        {
            screen.SetActive(true);

        }

    }

    public void hideTool()
    {
        //cafe = GameObject.Find("scene");
        // sky = GetComponent<Skybox>();
        if (tool.activeSelf == true)
        {
            tool.SetActive(false);


        }
        else
        {
            tool.SetActive(true);

        }

    }
}
