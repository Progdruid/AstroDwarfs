using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//this script is created only to contain all static scriptable objects

//cause of Unity's special way of working with scriptable objects
//Unity loads only SOs that are using in the scene
//so we need to manualy load static SOs
public class ConfigLoader : MonoBehaviour
{
    [SerializeField] IndexTable IndexTable;
}
