using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GridManager : MonoBehaviour
{
  
    [SerializeField] private HexSettings hexSettings;//параметры гекса

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
                float posX =x * hexSettings._hexWidth;
                if(y% 2 == 1){posX += hexSettings.heightMultiplier; }
                float posZ = y*hexSettings._hexHeigth;
                float posY = 0;
                //распологаем их по координатам из расчетов
                GameObject newHex = Instantiate(hexSettings.Hex,new Vector3(posX,posY,posZ),Quaternion.identity);
                HexTile hexTile = newHex.GetComponent<HexTile>();
                hexTile.SetCoordinates(x,y); // передача расположения гекса
                System.Array values = System.Enum.GetValues(typeof(HexTile.BiomeType));//Получаем количество значений в списке
                int randomIndex = Random.Range(0,values.Length);//Рандомно выбераем значения для создание цветов на поле
                HexTile.BiomeType randomBiome = (HexTile.BiomeType)values.GetValue(randomIndex);//навсякий случай приводим к определенному значению чтобы после нечиго не ломалось если у нас будет не int 
                hexTile.SetBiome(randomBiome);
                grid[x,y] = newHex.transform;
                newHex.transform.parent = transform;
            }
        }
    }
}
