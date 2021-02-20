using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using Photon.Pun;
using System.Data.Common;

public class draw : MonoBehaviour
{
    public GameObject brushs;
    public GameObject pen;
   
    private bool inputA;
    private bool inputX;
    private bool inputY;
    public GameObject p;
    public GameObject E;
    public GameObject bigParent;
    private List<GameObject> parent;
    private List<GameObject> cloneList;
    private List<List<GameObject>> parentList;
    [SerializeField] private bool grab;
    [SerializeField] private int num;
    private PhotonView PV;

    int k;

    // List <GameObject> sketch = new List <GameObject>();
    // Start is called before the first frame update

    // Update is called once per frame
    private void Start()
    {
        cloneList = new List<GameObject>();
        parentList = new List<List<GameObject>>();
        parentList.Add(cloneList);
        parent = new List<GameObject>();
        parent.Add(p);

        PV = GetComponent<PhotonView>();
        
    }

    void Update()
    {
        
        inputA = OVRInput.Get(OVRInput.RawButton.A);
        //inputX = OVRInput.GetDown(OVRInput.RawButton.X);
        inputY = OVRInput.GetDown(OVRInput.RawButton.Y);


        //if (inputA)
        //{
        //    Vector3 position = trackingSpace.TransformPoint(pen.transform.localPosition);
        //    Vector3 rotation = trackingSpace.TransformDirection(pen.transform.localRotation.eulerAngles);
        //    GameObject clone = Instantiate(brush, position, Quaternion.Euler(rotation));
        //}

        //if (inputY)
        //{
        //    if (brushs == pens[0])
        //    {
        //        brushs = pens[1];
        //    } else
        //    {
        //        brushs = pens[0];
        //    }

        //}



        //if (inputX)
        //{
        //    List <GameObject> cloneList2;
        //    cloneList2 = new List<GameObject>();
        //    parentList.Add(cloneList2);
        //    GameObject newp;
        //    newp = Instantiate(p);
        //    //newp = PhotonNetwork.Instantiate(p.name,Vector3.zero,Quaternion.identity);
        //    newp.transform.parent = bigParent.transform;

        //    parent.Add(newp);
        //    num += 1;
        //    newp.name = "Parent" + num;
        //}
        if (inputY)
        {
            PV.RPC("newParent", RpcTarget.All);
        }


        if (inputA)
        {
            Vector3 position = pen.transform.position;
            Vector3 rotation = pen.transform.rotation.eulerAngles;
            //GameObject clone = Instantiate(brushs, position, Quaternion.Euler(rotation),parent[num].transform);

            GameObject clone = PhotonNetwork.Instantiate(brushs.name, position, Quaternion.Euler(rotation));
            //clone.transform.SetParent (parent[num].transform);
            clone.transform.parent = parent[num].transform;
            parentList[num].Add(clone);

        }

        //if (PV.IsMine) { 
        // if (inputA)
        // {
        //     PV.RPC("drawSketch", RpcTarget.All);
        // }
        // }

        for (var p= 0; p < parentList.Count; p++)
        {
            var q = p ;

            for (var i = 0; i < parentList[q].Count; i++)
            {
                if (parentList[q][i].GetComponent<OVRGrabbable>().isGrabbed)
                {

                    k = i;
                    grab = true;
                    // cloneList.Add(cloneList[kp]);
                }

                if (grab == true)
                {
                    for (var j = 0; j < parentList[q].Count; j++)
                    {
                        parentList[q][j].transform.parent = parentList[q][k].transform;

                    }
                }
                else

                {
                    for (var j = 0; j < parentList[q].Count; j++)
                    {
                        parentList[q][j].transform.parent = parent[q].transform;

                    }
                }

            }
            grab = false;

        }

       

        //if (inputA)
        //{
        //    Vector3 position = trackingSpace.TransformPoint(OVRInput.GetLocalControllerPosition(OVRInput.Controller.LTouch));
        //    Vector3 rotation = trackingSpace.TransformDirection(OVRInput.GetLocalControllerRotation(OVRInput.Controller.LTouch).eulerAngles);
        //    GameObject clone = Instantiate(brush, position, Quaternion.Euler(rotation));
        //}

        //if (inputA)
        //{
        //    Vector3 position = pen.transform.position;
        //    Vector3 rotation = pen.transform.rotation.eulerAngles;
        //    GameObject clone = Instantiate(brush, position, Quaternion.Euler(rotation), parent.transform);
        //    parentList[num].Add(clone);

        //}

        //for (var i = 0; i < cloneList.Count; i++)
        //{
        //    if (parentList[num][i].GetComponent<OVRGrabbable>().isGrabbed)
        //    {

        //        k = i;
        //        grab = true;
        //        // cloneList.Add(cloneList[kp]);
        //    }

        //    if (grab == true)
        //    {
        //        for (var j = 0; j < cloneList.Count; j++)
        //        {
        //            cloneList[j].transform.parent = cloneList[k].transform;

        //        }
        //    }
        //    else

        //    {
        //        for (var j = 0; j < cloneList.Count; j++)
        //        {
        //            cloneList[j].transform.parent = parent.transform;

        //        }
        //    }

        //}
        //grab = false;
    }

    //[PunRPC]
    //void drawSketch()
    //{
        
    //    Vector3 position = pen.transform.position;
    //    Vector3 rotation = pen.transform.rotation.eulerAngles;
        
    //    GameObject clone = Instantiate(brushs, position, Quaternion.Euler(rotation),parent[num].transform);
       
    //    //GameObject clone = PhotonNetwork.Instantiate(brushs.name, position, Quaternion.Euler(rotation));
    //    clone.transform.SetParent (parent[num].transform);
    //    //clone.transform.parent = parent[num].transform;
    //    parentList[num].Add(clone);
    //}

    [PunRPC]
    void newParent() {
        List<GameObject> cloneList2;
        cloneList2 = new List<GameObject>();
        parentList.Add(cloneList2);
        GameObject newp;
        newp = Instantiate(E);
        //newp = PhotonNetwork.Instantiate(p.name,Vector3.zero,Quaternion.identity);
        newp.transform.parent = bigParent.transform;

        parent.Add(newp);
        num += 1;
        newp.name = "Parent" + num;
    }

}






    
