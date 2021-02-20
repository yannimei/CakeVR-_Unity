using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject photo;
    public GameObject cam;
    void Start()
    {
        
    }

    // Update is called once per frame
    public void showCamera()
        
    {

        if (photo.activeSelf == true)
        {
            photo.SetActive(false);


        }
        else
        {
            photo.SetActive(true);

        }

    }
    
    public void switchCamera()
    {
        
        
            cam.transform.localRotation *= Quaternion.Euler(0, 180, 0);
        

        
    }
}
