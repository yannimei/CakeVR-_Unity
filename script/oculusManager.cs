using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oculusManager : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject head;
    public GameObject lhand;
    public GameObject rhand;
    public static oculusManager instance;


    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }

}
