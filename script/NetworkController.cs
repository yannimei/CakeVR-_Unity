using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;


// For use with Photon 
public class NetworkController : MonoBehaviourPunCallbacks
{
    
    string _room = "cake";
    //public GameObject headprefab;
    //public GameObject lhprefab;
    //public GameObject rhprefab;

    void Start()
    {
        print("connecting");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("connected");

        RoomOptions room = new RoomOptions() { };
        PhotonNetwork.JoinOrCreateRoom(_room, room, TypedLobby.Default);
    }


    public override void OnCreatedRoom()
    {
        print("created");
    }

    public override void OnJoinedLobby()
    {
        print("joined lobby");

        //RoomOptions room = new RoomOptions() { };
        //PhotonNetwork.JoinOrCreateRoom(_room, room, TypedLobby.Default);
    }

    public override void OnJoinedRoom()
    {
        print("joined");
        PhotonNetwork.Instantiate("NetworkPlayer2", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("avatarLeftHand", Vector3.zero, Quaternion.identity, 0);
        PhotonNetwork.Instantiate("avatarRightHand", Vector3.zero, Quaternion.identity, 0);

        //PhotonNetwork.Instantiate(headprefab.name, oculusManager.instance.head.transform.position, oculusManager.instance.head.transform.rotation, 0);
        //PhotonNetwork.Instantiate(lhprefab.name, oculusManager.instance.lhand.transform.position, oculusManager.instance.lhand.transform.rotation, 0);
        //PhotonNetwork.Instantiate(rhprefab.name, oculusManager.instance.rhand.transform.position, oculusManager.instance.rhand.transform.rotation, 0);

    }

}