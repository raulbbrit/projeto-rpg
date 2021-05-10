using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectButton :  MonoBehaviour
{
    [SerializeField] private GameObject objectPreFab;
    [SerializeField] private GameObject objectIcon;

    //Selected Object List: 
    public GameObject ObjectPrefab { get => objectPreFab; }
    public GameObject ObjectIcon { get => objectIcon; }
}
