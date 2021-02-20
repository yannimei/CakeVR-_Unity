using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro.EditorUtilities;
using UnityEngine;
using Photon.Pun;
public class showInterface : MonoBehaviour
{
    public GameObject[] buttons;
    public GameObject[] tabs;
    public int tabNum;
    public int buttonNum;
    public PhotonView PV;

    // Start is called before the first frame update
    void Start()
    {
        PV = GetComponent<PhotonView>();
    }





    public void show(int buttonN)
    {
        buttonNum = buttonN;
        PV.RPC("showButtonNumber", RpcTarget.All,buttonNum);
    }

    public void showTab(int tabN)
    {
        tabNum = tabN;
        PV.RPC("showTheTab", RpcTarget.All, tabNum);
    }

    //public void showTab(int b)
    //{
    //    for (var i = 0; i < tabs.Count(); i++)
    //    {
    //        if (i != b)
    //        {
    //            //tabs[i].SetActive(false);
    //            tabs[i].transform.localScale = Vector3.zero;
    //        }
    //        else
    //        {
    //            //tabs[i].SetActive(true);
    //            tabs[i].transform.localScale = new Vector3(1, 1, 1);
    //        }
    //    }
    //}

    [PunRPC]
    void showTheTab (int b)
    {
        tabNum = b;
        for (var i = 0; i < tabs.Count(); i++)
        {
            if (i != tabNum)
            {
                //tabs[i].SetActive(false);
                tabs[i].transform.localScale = Vector3.zero;
            }
            else
            {
                //tabs[i].SetActive(true);
                tabs[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }

    [PunRPC]
    void showButtonNumber( int a)
    {
        buttonNum = a;
        for (var i = 0; i < buttons.Count(); i++)
        {
            if (i != buttonNum)
            {
                buttons[i].transform.localScale = Vector3.zero;
            }
            else
            {
                //buttons[i].SetActive(true);
                buttons[i].transform.localScale = new Vector3(1, 1, 1);
            }
        }
    }
}
