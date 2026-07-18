using System.IO.Compression;
using UnityEngine;
using UnityEditor.UI;
using UnityEngine.UI;
using Unity.VisualScripting;

public class HexGrid : MonoBehaviour
{
    public int _h = 6;
    public int _w = 6;


    public Color defaultColor = Color.white;
    public Color touchedColor = Color.magenta;


    public HexCell cellPrefab;
    
    HexCell[] cells;


    public Text cellLabalPrefab;

    Canvas gridCanvas;

    HexCell hexMesh;


    void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexCell>();

        cells = new HexCell[_h * _w];

        for(int z = 0, i = 0; z < _h; z++)
        {
            for(int x = 0; x < _w; x++)
            {
                CreatCell(x,z,i++);
            }
        }
    }

    void Start()
    {
        hexMesh.Triangulate(cells);
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            HandleInput();
        }
    } 

    void CreatCell(int x,int z, int i)
    {

        Vector3 position;
		position.x = (x + z * 0.5f - z / 2) * (HexMetrics._innerRadius * 2f);
		position.y = 0f;
		position.z = z * (HexMetrics._outerRadius *1.5f);

		HexCell cell = cells[i] = Instantiate<HexCell>(cellPrefab);
		cell.transform.SetParent(transform, false);
		cell.transform.localPosition = position;
        cell._coordinates = HexCoordinates1.FromeoffsetCordinates(x,z);
        cell._color = defaultColor;

        Text label = Instantiate<Text>(cellLabalPrefab);
		label.rectTransform.SetParent(gridCanvas.transform, false);
		label.rectTransform.anchoredPosition =
			new Vector2(position.x, position.z);
		label.text = cell._coordinates.ToStringOnSeparateLines();

    } 

    void HandleInput()
    {
        Ray inputRay = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(inputRay, out hit))
        {
            TouchCell(hit.point);
        }
    }

    void TouchCell(Vector3 position)
    {
        position = transform.InverseTransformPoint(position);
        HexCoordinates1 coordinates = HexCoordinates1.FromPosition(position);
        int index = coordinates.X + coordinates.Z * _w + coordinates.Z/2;
        HexCell cell = cells[index];
        cell._color = touchedColor;
        hexMesh.Triangulate(cells);
    }


}
