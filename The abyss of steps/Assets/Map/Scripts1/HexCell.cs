using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer))]
public class HexCell : MonoBehaviour
{
   Mesh _hexMesh;
   List<Vector3> _vertices;
   List<int> _triangles;

   public HexCoordinates1 _coordinates;
   public Color _color;

   List<Color> _colors;

   MeshCollider _meshCollider;

    void Awake()
    {
        GetComponent<MeshFilter>().mesh = _hexMesh = new Mesh();
        _meshCollider = gameObject.AddComponent<MeshCollider>();
        _hexMesh.name = "Hex Mesh";
        _vertices = new List<Vector3>();
        _colors = new List<Color>();
        _triangles = new List<int>();
    }

    void AddTriangle (Vector3 v1, Vector3 v2, Vector3 v3) {
		int vertexIndex = _vertices.Count;
		_vertices.Add(v1);
		_vertices.Add(v2);
		_vertices.Add(v3);
		_triangles.Add(vertexIndex);
		_triangles.Add(vertexIndex + 1);
		_triangles.Add(vertexIndex + 2);
	}

        public void Triangulate(HexCell[] cells)
    {
        _hexMesh.Clear();
		_vertices.Clear();
        _colors.Clear();
		_triangles.Clear();
		for (int i = 0; i < cells.Length; i++) {
			Triangulate(cells[i]);
		}
		_hexMesh.vertices = _vertices.ToArray();
        _hexMesh.colors = _colors.ToArray();
		_hexMesh.triangles = _triangles.ToArray();
		_hexMesh.RecalculateNormals();

        _meshCollider.sharedMesh = _hexMesh;
    }

    private void Triangulate(HexCell cell)
    {
        Vector3 center = cell.transform.localPosition;
        for (int i = 0; i < 6; i++) {
			AddTriangle(
				center,
				center + HexMetrics._corners[i],
				center + HexMetrics._corners[i + 1]
			);
            AddTriangleColor(cell._color);
        }
    }

    void AddTriangleColor(Color color)
    {
        _colors.Add(color);
        _colors.Add(color);
        _colors.Add(color);
    }
}
