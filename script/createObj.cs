using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class createObj : MonoBehaviour
{

    public GameObject[] obj;
    public GameObject point;
   // private PhotonView photonview;
   
    //[SerializeField] private int objNumber;
    //[SerializeField] private bool yes;

    // Start is called before the first frame update
    void Start()
    {
       // photonview = GameObject.Find("operation").GetComponent<PhotonView>();
    }

    void Update()
    {
        if (Input.GetKeyDown("6"))
        {
            PhotonNetwork.Instantiate(obj[0].name, GameObject.Find("Cube").transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
            print("haha");
            
        }
        //if (Input.GetKeyDown("6"))
        //{
        //    photonview.RPC("createO", RpcTarget.All,0);
        //}
        print(Input.GetKeyDown("6"));
    }


    public void create( int a)
    {
       
       // Instantiate(obj[a], point.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
        PhotonNetwork.Instantiate(obj[a].name, point.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity,0);
    }

    //[PunRPC]
    //void createO()
    //{
    //    Instantiate(obj[0], point.transform.position + new Vector3(0, 0.1f, 0), Quaternion.identity);
    //}
    
}
