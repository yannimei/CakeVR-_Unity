using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;
using System.Linq;

public class selfActive : MonoBehaviour
{
    private PhotonView photonview;
    public GameObject me;
    private float s, t, sc,cam,park;
    public int index;
    private Vector3 toolbarscale;
   
    public bool _switchScene;
    public bool _Tool;
    public bool _Screen;
    public bool _Cam;
    
    // Start is called before the first frame update
    void Start()
    {
        photonview = GetComponent<PhotonView>();
        s = 1;
        t = 1;
        sc = 1;
        cam = 0;
        park = 0;
        toolbarscale = GameObject.Find("toolbar").transform.localScale;
       //toolbarscale = new Vector3(0.01f, 0.01f, 1);

    }

    // Update is called once per frame
    
    public void switchScene()
    {
        _switchScene = true;
    }
    public void hideTool()
    {
        _Tool = true;
    }

    public void hideScreen()
    {
        _Screen = true;
    }
    public void showCam()
    {
        _Cam = true;
    }




    void Update()
    {

        switch (index)
        {
            case 1:
                
                    //if (Input.GetKeyDown("2"))
                    if (_switchScene)
                    {
                        if (s == 0)
                        {
                            s = 1;
                        }
                        else
                        {
                            s = 0;
                        }
                    photonview.RPC("hideCafe", RpcTarget.AllBuffered, s);
                    
                    }
              
                _switchScene = false;

                break;

            case 2:
                if (_Tool )
                {
                    
                        if (t == 0)
                        {
                            t = 1;
                        }
                        else
                        {
                            t = 0;
                        }
                        photonview.RPC("hidetool", RpcTarget.AllBuffered, t);
                    
                }
                    _Tool = false;
                break;
            
            case 3:
                if (_Screen)
                {

                    if (sc == 0)
                    {
                        sc = 1;
                    }
                    else
                    {
                        sc = 0;
                    }
                    photonview.RPC("hide", RpcTarget.AllBuffered, sc);

                }
                _Screen = false;
                break;
            
            case 4:
                if (_Cam)
                {

                    if (cam == 0)
                    {
                        cam = 1;
                    }
                    else
                    {
                        cam = 0;
                    }
                    photonview.RPC("showCamRpc", RpcTarget.All, cam);

                }
                _Cam = false;
                break;

            case 5:

                //if (Input.GetKeyDown("2"))
                if (_switchScene)
                {
                    if (park == 0)
                    {
                        park = 1;
                    }
                    else
                    {
                        park = 0;
                    }
                    photonview.RPC("hideCafe", RpcTarget.AllBuffered, park);

                }

                _switchScene = false;

                break;



        }


    }

    //public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    //{

    //    if (stream.IsWriting)
    //    {
    //        //stream.SendNext(playerGlobal.position);
    //        //stream.SendNext(playerGlobal.rotation);
    //        //stream.SendNext(playerLocal.localPosition);
    //        //stream.SendNext(playerLocal.localRotation);
    //        stream.SendNext(me.activeSelf);
    //    }
    //    else
    //    {
    //        //this.transform.position = (Vector3)stream.ReceiveNext();
    //        //this.transform.rotation = (Quaternion)stream.ReceiveNext();
    //        //avatar.transform.localPosition = (Vector3)stream.ReceiveNext();
    //        //avatar.transform.localRotation = (Quaternion)stream.ReceiveNext();
    //        me.SetActive((bool)stream.ReceiveNext());

    //    }
    //}




    [PunRPC]
    public void hideCafe(float a)
    {
        s = a;
        if (s == 0)
        {
            me.transform.localPosition += new Vector3(1000, 0, 0);
        }

        if (s == 1)
        {
            me.transform.localPosition -= new Vector3(1000, 0, 0);
        }
    }

    [PunRPC]
    public void showPark(float a)
    {
        park = a;
        if (park == 0)
        {
            me.transform.localPosition += new Vector3(1000, 0, 0);
        }

        if (park == 1)
        {
            me.transform.localPosition -= new Vector3(1000, 0, 0);
        }
    }







    [PunRPC]
    public void hidetool(float a)
    {
        if (a == 0)
        {
            me.transform.localScale = new Vector3(0, 0, 0);
        }

        if (a == 1)
        {
            me.transform.localScale = toolbarscale;
        }
    }


    [PunRPC]
    public void hide(float a)
    {
        sc = a;
        if (sc == 0)
        {
            me.transform.localScale = new Vector3(0, 0, 0);
        }

        if (sc == 1)
        {
            me.transform.localScale = new Vector3(1, 1, 1);
        }
    }



    [PunRPC]
    public void showCamRpc(float a)
    {
        if (a == 0)
        {
            me.transform.localScale = new Vector3(0, 0, 0);
        }

        if (a == 1)
        {
            me.transform.localScale = new Vector3(0.4f, 0.4f, 0.2f);
        }
    }




}
