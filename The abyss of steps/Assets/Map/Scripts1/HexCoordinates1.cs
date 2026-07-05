using UnityEngine;

[System.Serializable]
public struct HexCoordinates1
{
    public int X{get;private set; }
    public int Z{get; private set; }

    public HexCoordinates1(int x, int z)
    {
        X = x;
        Z = z;
    }
}
