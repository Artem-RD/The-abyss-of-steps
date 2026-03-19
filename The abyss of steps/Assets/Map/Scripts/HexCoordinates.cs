using Unity.Collections;
using UnityEngine;

public struct HexCoordinates 
{
   public  int _Q;
   public  int _R;
   public int S { get { return -_Q - _R; } }

   public HexCoordinates(int q, int r) { _Q = q; _R = r; }

   //расчитываем координаты
   public static HexCoordinates FromOffsetCoordinates(int x, int y)
    {
        int q = x;
        int r = y - (x +(x & 1))/2;//вычисляем z координату
        return new HexCoordinates(q,r);
    }
}
