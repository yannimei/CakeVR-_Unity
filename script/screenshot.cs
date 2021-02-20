using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class screenshot : MonoBehaviour
{
    public int resWidth = 3200;
    public int resHeight = 2400;
    public Camera cameraMe;
    public GameObject photo;
    public GameObject point;
    
    public bool shot = false;



    //public static string ScreenShotName(int width, int height)
    //{
    //    return string.Format("{0}/screenshots/screen_{1}x{2}_{3}.png",
    //                         Application.dataPath,
    //                         width, height,
    //                         System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
    //}

    



    public void TakeHiResShot()
    {
        shot = true;
    }

    void Update()
    {
        
        if (shot)
        {
            
            RenderTexture original = cameraMe.targetTexture;
            RenderTexture rt = new RenderTexture(resWidth, resHeight, 24);
            cameraMe.targetTexture = rt;
            Texture2D screenShot = new Texture2D(resWidth, resHeight, TextureFormat.RGB24, false);
            cameraMe.Render();
            RenderTexture.active = rt;
            screenShot.ReadPixels(new Rect(0, 0, resWidth, resHeight), 0, 0);
            screenShot.Apply();
           
            cameraMe.targetTexture = original;
            RenderTexture.active = null; // JC: added to avoid errors
            Destroy(rt);

            //byte[] bytes = screenShot.EncodeToPNG();
            //GameObject newphoto = Instantiate(photo, point.transform.position + new Vector3(0, 0.01f, 0), Quaternion.identity);
            GameObject newphoto = PhotonNetwork.Instantiate(photo.name, point.transform.position + new Vector3(0, 0.01f, 0), Quaternion.identity);
            newphoto.GetComponent<Renderer>().material.mainTexture = screenShot;


            //string filename = ScreenShotName(resWidth, resHeight);
            //System.IO.File.WriteAllBytes(filename, bytes);
            //Debug.Log(string.Format("Took screenshot to: {0}", filename));
            shot = false;
        }
    }
}