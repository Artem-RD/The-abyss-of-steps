using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
    //поля для гекса префаб(гекс), размеры ширина и длинна самого гекса
  [SerializeField] private GameObject Hex;
    private float _hexWidth = 2.996f;//ширина(не менять значение сетка сломаеться)
    private float _hexHeigth =0.866f;//высота(не менять значение сетка сломаеться)
    public float heightMultiplier = 1.498f;// шаг с кторым надо ставить следующий гекс(не менять сетка сломаеться)

    //поля для создания сетки для расположения гексов
    private int _whidth = 10;
    private int _heigth = 10;
    private Transform [,]grid;
   
    void Start()
    {
       GenerateGrid();
    }


    void Update()
    {
        
    }


//в этом методе мы строим сетку(поле) и передаем расположение гекса в следующий класс для взаимодействия с ними
   private void  GenerateGrid()
    {
        grid = new Transform[_whidth,_heigth];
        for(int y = 0; y < _heigth; y++)
        {
            for(int x = 0; x< _whidth; x++)
            {
                //считаем расположение гексов
                float posX =x * _hexWidth;
                if(y% 2 == 1){posX += heightMultiplier; }
                float posZ = y*_hexHeigth;
                float posY = 0;
                //распологаем их по координатам из расчетов
                GameObject newHex = Instantiate(Hex,new Vector3(posX,posY,posZ),Quaternion.identity);
                HexTile hexTile = newHex.GetComponent<HexTile>();
                hexTile.SetCoordinates(x,y); // передача расположения гекса
                grid[x,y] = newHex.transform;
                newHex.transform.parent = transform;
            }
        }
    }
}
