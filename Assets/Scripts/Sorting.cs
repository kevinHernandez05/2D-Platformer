using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sorting : MonoBehaviour
{
    public string SortingLayerName;
    public int SortingOrder = 0;

    void Start()
    {
        gameObject.GetComponent<MeshRenderer>().sortingLayerName = SortingLayerName;
        gameObject.GetComponent<MeshRenderer>().sortingOrder = SortingOrder;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
