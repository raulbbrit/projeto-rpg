using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectButton :  MonoBehaviour
{
    [SerializeField] private GameObject mapObjectPreFab;
    [SerializeField] private GameObject objectPrefab;
    [SerializeField] private GameObject objectIcon;

    //Selected Object List: 
    public GameObject MapObjectPreFab { get => mapObjectPreFab; }
    public GameObject ObjectIcon { get => objectIcon; }
    public GameObject ObjectPrefab { get => objectPrefab;}
}
