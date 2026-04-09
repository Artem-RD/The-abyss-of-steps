using UnityEngine;

[CreateAssetMenu(fileName = "HexSettings", menuName = "Scriptable Objects/HexSettings")]
public class HexSettings : ScriptableObject
{
    public GameObject Hex;
    public float _hexHeigth;//высота гекса(позже можно попытаться сделать автоматически пока параметр указываеться в ручную(не обязательно исправлять))
    public float _hexWidth;//ширина гекса(позже можно попытаться сделать автоматически пока параметр указываеться в ручную(не обязательно исправлять))
    
    public float _noisScale; // свойство для распростронения шума генерации биомов 

}
