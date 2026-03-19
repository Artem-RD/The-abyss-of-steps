using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
  
    [SerializeField] private HexSettings hexSettings;//параметры гекса

    private Dictionary<HexCoordinates,HexTile> _hexDict = new Dictionary<HexCoordinates, HexTile>();// словарь для хранения ближайших гексов

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
                //передаем кубические координаты
                HexCoordinates coords = HexCoordinates.FromOffsetCoordinates(x, y);
                //считаем расположение гексов
                float posX = (coords._Q + coords._R * 0.5f) * hexSettings._hexWidth;
                float posZ = coords._R * hexSettings._hexHeigth;
                float posY = 0;
                //распологаем их по координатам из расчетов
                GameObject newHex = Instantiate(hexSettings.Hex,new Vector3(posX,posY,posZ),Quaternion.identity);
                HexTile hexTile = newHex.GetComponent<HexTile>(); 
                hexTile.SetCoordinates(coords); // передача расположения гекса
                _hexDict[coords] = hexTile;//передача расположения ближайших гексов
                System.Array values = System.Enum.GetValues(typeof(HexTile.BiomeType));//Получаем количество значений в списке
                int randomIndex = UnityEngine.Random.Range(0,values.Length);//Рандомно выбераем значения для создание цветов на поле
                HexTile.BiomeType randomBiome = (HexTile.BiomeType)values.GetValue(randomIndex);//навсякий случай приводим к определенному значению чтобы после нечиго не ломалось если у нас будет не int 
                hexTile.SetBiome(randomBiome);
                grid[x,y] = newHex.transform;
                newHex.transform.parent = transform;
            }
        }
    }
}
