using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneTransitionManager : MonoBehaviour
{
    

    public static void Return()
    {
        GameObject networkManager;
        networkManager = GameObject.Find("NetworkManager");
        Destroy(networkManager);
    }
}
