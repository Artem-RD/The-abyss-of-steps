using UnityEngine;
using UnityEditor;
using System.Reflection.Emit;

[CustomPropertyDrawer(typeof(HexCoordinates1))]
public class HexCoordinatesDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        HexCoordinates1 coordinates = new HexCoordinates1(
            property.FindPropertyRelative("x").intValue,
            property.FindPropertyRelative("z").intValue
        );

        position = EditorGUI.PrefixLabel(position,label);
        GUI.Label(position,coordinates.ToString());
    }
}
