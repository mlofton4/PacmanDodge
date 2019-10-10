using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class DestroyFloatingText : MonoBehaviour
{
    private float DestroyTime = 10f;
    //private Vector3 offset = new Vector3(0f,2f,0f);
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, DestroyTime);
        //transform.localPosition += offset;
    }

}
