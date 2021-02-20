using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class buttonSync : MonoBehaviour
{
    private int buttonColor;
    private PhotonView PV;
    // Start is called before the first frame update
    void Start()
    {
        buttonColor = 0;
        PV = GetComponent<PhotonView>();
    }

    // Update is called once per frame
    void Update()
    {
        PV.RPC("changeButtonColor", RpcTarget.All, buttonColor);
        PV.RPC("changeButtonColor", RpcTarget.All, buttonColor);
    }




    public void redB()
    {
        buttonColor = 1;
    }
    public void whiteB()
    {
        buttonColor = 0;
    }


    [PunRPC]
    void changeButtonColor(int a)
    {
        buttonColor = a;
        if (buttonColor == 1)
        {
            this.GetComponent<Image>().color = Color.red;
        }
        if (buttonColor == 0)
        {
            this.GetComponent<Image>().color = Color.white;
        }
    }
}
