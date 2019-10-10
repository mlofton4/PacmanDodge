using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class GeneratePacdots : MonoBehaviour
{
    [SerializeField] GameObject prefab = null;
    [SerializeField] GameObject cube = null;

    // Start is called before the first frame update
    void Start()
    {
        Vector3 offset = new Vector3(0f, 0f, 0f);
        cube.GetComponent<Renderer>().enabled = false;
        Instantiate(prefab, cube.transform.position + offset, Quaternion.identity);
    }
}
