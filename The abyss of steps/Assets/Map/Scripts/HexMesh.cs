using System.Collections.Generic;
using TMPro;
using UnityEditor.SettingsManagement;
using UnityEngine;

public class HexMesh : MonoBehaviour
{
    private  List<Vector3> _vertex;
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
        Vector3[] _corners = new Vector3[6];
        float _width =  settings._hexWidth;
        float _height = settings._hexHeigth;
        float outerRadius = _width / 2f;
        float innerRadius = _height / 2f;
        _corners[0] = new Vector3(0, 0,  outerRadius);
        _corners[1] = new Vector3( innerRadius, 0,  outerRadius/2);
        _corners[2] = new Vector3( innerRadius, 0, -outerRadius/2);
        _corners[3] = new Vector3(0, 0, -outerRadius);
        _corners[4] = new Vector3(-innerRadius, 0, -outerRadius/2);
        _corners[5] = new Vector3(-innerRadius, 0,  outerRadius/2);

        _vertex = new List<Vector3>();
        _triangels = new List<int>();
        _colors = new List<Color>();
        foreach (var kvp in _dataDict)
        {
            HexCoordinates coords = kvp.Key;
            Color _color = kvp.Value.GetColorForBiome(kvp.Value._currentType);
            float centerX = (coords._Q + coords._R * 0.5f)* settings._hexWidth;
            float centerZ = coords._R * settings._hexHeigth;
            Vector3 center = new Vector3(centerX,0,centerZ);
            for (int i = 0; i < 6; i++)
            {
              Vector3 v0 = center;
              Vector3 v1 = center + _corners[i];
              Vector3 v2 = center + _corners[(i+1)%6];
              _vertex.Add(v0);
              _vertex.Add(v1);
              _vertex.Add(v2);
              _triangels.Add(_vertex.Count-3);
              _triangels.Add(_vertex.Count -2);
              _triangels.Add(_vertex.Count - 1);
              _colors.Add(_color);
              _colors.Add(_color);
              _colors.Add(_color);
            }
        }
        Mesh mesh = new Mesh();
        mesh.vertices = _vertex.ToArray();
        mesh.triangles = _triangels.ToArray();
        mesh.colors = _colors.ToArray();
        mesh.RecalculateNormals();
       _meshFilter.mesh = mesh;
        _meshCollider.sharedMesh = mesh;
        
         
    }
}
