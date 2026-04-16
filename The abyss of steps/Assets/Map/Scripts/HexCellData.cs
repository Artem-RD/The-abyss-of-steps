using UnityEngine;

public class HexCellData
{
    // координаты гексы
    public HexCoordinates _coordinates;
    //массив соседей гекса
   public HexCellData[] _neighbors = new HexCellData[6];

// создание биома по типу
    public BiomeType _currentType;


   //метод для получения ссылки на соседей
    public void SetNeighbor(int direction, HexCellData neighbor)
    {
        _neighbors[(int)direction] = neighbor;
    }
    //метод получения соседей 
    public HexCellData GetNeighbor(int direction)
    {
       return _neighbors[(int)direction];
    }

// передача координат и типа биома
    public HexCellData(HexCoordinates coords, BiomeType biome)
    {
        _coordinates = coords;
        _currentType = biome;
    }

//метод передачи цвета биому
    public Color GetColorForBiome(BiomeType type)
    {
       Color color = Color.white;
        switch(type)
        {
            case BiomeType.Grass: return Color.green ;
            case BiomeType.Water: return Color.skyBlue;
            case BiomeType.Desert: return Color.saddleBrown;
            case BiomeType.Moutain: return Color.gray;
            default: return Color.white;


        } 
    }

}
