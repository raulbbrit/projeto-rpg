using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickObjectButton : MonoBehaviour
{
    [SerializeField] private GameObject ObjectPreFab;
    [SerializeField] private GameObject hoverIcon;
    //Selected Object List: 
    public GameObject ObjectPrefab { get => ObjectPreFab;}
    public GameObject HoverIcon { get => hoverIcon;}
}
