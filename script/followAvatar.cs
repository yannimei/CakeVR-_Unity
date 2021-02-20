using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class followAvatar : MonoBehaviour
    
{
    public int index = 1;
    // Start is called before the first frame update
    

    // Update is called once per frame
   void Update()
    {
        if (GetComponent<PhotonView>().IsMine)
        {
            
            switch (index)
            {
                case 1:
                    transform.position = oculusManager.instance.head.transform.position;
                    transform.rotation = oculusManager.instance.head.transform.rotation;

                    break;

                case 2:
                    transform.position = oculusManager.instance.lhand.transform.position;
                    transform.rotation = oculusManager.instance.lhand.transform.rotation;

                    break;

                case 3:
                    transform.position = oculusManager.instance.rhand.transform.position;
                    transform.rotation = oculusManager.instance.rhand.transform.rotation;
                    break;

            }
               


           
        }
    }
}
