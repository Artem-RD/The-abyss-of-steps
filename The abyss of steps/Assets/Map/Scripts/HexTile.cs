using Unity.Collections;
using Unity.Properties;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HexTile : MonoBehaviour
{
    // координаты гексы
    int _gridX;
    int _gridY;

    // перечисление биомов( возможно временно)

   public enum BiomeType
    {
        Grass,
        Water,
        Desert,
        Moutain
    }

// наложение текстур для биомов
    private BiomeType _currentType;

    MaterialPropertyBlock _material;
    Renderer _renderer;
    private Color _colorBiome;

    void Awake()
    {
        _material = new MaterialPropertyBlock();

        _renderer = GetComponent<Renderer>();
    }

// присвоение координат дле гексов
    public void SetCoordinates(int x, int y)
    {
        _gridX = x;
        _gridY = y;
    }

//присвоение цвета для биома(нужно доработать чтобы после можно было менять на текстуры и добавить ландшафт для определенных биомов)
    public void SetBiome(BiomeType type)
    {
        _currentType = type;// временно нигед не применяеться (можно испоьльзавть для чего-то)
        Color color = Color.white;
        switch(type)
        {
            case BiomeType.Grass: color = Color.green ; _colorBiome = color;
            break;
            case BiomeType.Water: color = Color.skyBlue;_colorBiome = color;
            break;
            case BiomeType.Desert: color = Color.saddleBrown;_colorBiome = color;
            break;
            case BiomeType.Moutain: color = Color.gray;_colorBiome = color;
            break;

        }
        _material.SetColor("_Color",color);
        _renderer.SetPropertyBlock(_material);
    }
//методы для старой системы ввода в Unity в будушем возможны конфликты 
    void OnMouseEnter()
    {
         _material.SetColor("_Color",Color.yellow);
        _renderer.SetPropertyBlock(_material);
    }

    void OnMouseExit()
    {
         _material.SetColor("_Color",_colorBiome);
        _renderer.SetPropertyBlock(_material);
    }

}
