using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tester : MonoBehaviour
{
    void Start()
    {
        A first = new A();
        A second = new B();
        A NULL = null;

        Debug.Log($"First is A: {first is A}, is B: {first is B}");
        Debug.Log($"Second is A: {second is A}, is B: {second is B}");
        Debug.Log($"NULL is A: {NULL is A}, is B: {NULL is B}");
    }
}

public class A
{

}

public class B : A
{

}