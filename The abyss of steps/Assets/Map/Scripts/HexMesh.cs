using System.Collections.Generic;
using UnityEngine;

public class HexMesh : MonoBehaviour
{     private  List<Vector3> _vertex;
      private List<int> _triangels;
      private  List<Color> _colors;
      private MeshFilter _meshFilter;
      private MeshCollider _meshCollider;
      
     void Start()
    {
        _meshCollider = GetComponent<MeshCollider>();
        _meshFilter = GetComponent<MeshFilter>();
    }


    void Update()
    {
        
    }

    public void BuildMesh(Dictionary<HexCoordinates,HexCellData> _dataDict,HexSettings settings)
    {
        _vertex = new List<Vector3>();
        _triangels = new List<int>();
        _colors = new List<Color>();
        for (int i = 0; i <= _dataDict.Count; i++)
        {
            
        }
         
    }
}
