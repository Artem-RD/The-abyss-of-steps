using System.Collections.Generic;
using UnityEngine;

public class HexMesh : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BuildMesh(Dictionary<HexCoordinates,HexCellData> _dataDict,HexSettings settings)
    {
        List<Vector3> vertex;
        List<int> triangels;
        List<Color> colors;
        MeshFilter meshFilter = GetComponent<MeshFilter>();
        MeshCollider meshCollider = GetComponent<MeshCollider>();
         
    }
}
