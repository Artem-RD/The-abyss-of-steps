using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using Unity.Mathematics;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
  
    [SerializeField] private HexSettings hexSettings;//параметры гекса

    
    private int _deltaQ;
    private int _deltaR;
    private Dictionary<HexCoordinates,HexTile> _hexDict = new Dictionary<HexCoordinates, HexTile>();// словарь для хранения ближайших гексов

    //поля для создания сетки для расположения гексов
    private int _whidth = 10;
    private int _heigth = 10;
    private Transform [,]grid;

    public enum HexDirection
    {
        Ne,
        E,
        SE,
        SW,
        W,
        NW
    }

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
                EstablishNeighbors(); // поиск соседий и передача информации об них
            }
        }
    }

    private void EstablishNeighbors()
    {
         foreach (var kvp in _hexDict)
        {
            HexTile currentHex = kvp.Value;
            HexCoordinates currentCoords = kvp.Key;//передача координат ближайших соседей гекса
            foreach(var cor in Enum.GetValues(typeof(HexDirection)))
            {
                switch (cor)
              {
                case HexDirection.Ne:  _deltaQ =1; _deltaR = -1;
                break;
                case HexDirection.E: _deltaQ= 1;_deltaR = 0;
                break;
                case HexDirection.SE: _deltaQ = 0;_deltaR=1;
                break;
                case HexDirection.SW: _deltaQ =-1;_deltaR =1;
                break;
                case HexDirection.W: _deltaQ =-1;_deltaR = 0;
                break;
                case HexDirection.NW: _deltaQ = 0; _deltaR = -1;
                break;
              }
              int neighborQ = currentCoords._Q + _deltaQ;
              int neighborR = currentCoords._R + _deltaR;
              HexCoordinates neighborCoords = new HexCoordinates(neighborQ, neighborR);
              if(_hexDict.TryGetValue(neighborCoords, out HexTile neighbor))
                {
                    currentHex.SetNeighbor((int)cor,neighbor);
                }
            }
            
            
        }
    }
}
