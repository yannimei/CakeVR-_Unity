using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class getImage : MonoBehaviour
{
    public GameObject[] pic;
    public GameObject point;
    public Transform pictures;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void show (int a)
    {
        pic[a].SetActive (true);
        //Instantiate( pic[a], point.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(pic[a].name, point.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    }

    
}
