using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
   
    private GameObject networkManager;
    void Start()
    {
        networkManager = GameObject.Find("NetworkManager");
        Destroy(networkManager);
    }
}
