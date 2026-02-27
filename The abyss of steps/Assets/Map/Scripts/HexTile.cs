using Unity.Collections;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class HexTile : MonoBehaviour
{
    int _gridX;
    int _gridY;

    enum BiomeType
    {
        Grass,
        Water,
        Desert,
        Moutain
    }

    private BiomeType _currentType;

    public void SetCoordinates(int x, int y)
    {
        _gridX = x;
        _gridY = y;
    }

    /*public void SetBiome(BiomeType type)
    {
        _currentType = type;
        switch(type)
        {
            case 1: return ;
            
        }
    }*/
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}
