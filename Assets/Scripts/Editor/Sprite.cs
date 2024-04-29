using System.Globalization;
using UnityEditor;
using UnityEngine;

namespace Editor
{
    [CustomEditor(typeof(Items.SO.Items))]
    public class Sprite : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            Items.SO.Items itemsDataSO = (Items.SO.Items)target;

            if (itemsDataSO.ItemsData != null)
            {
                EditorGUILayout.Space();
                EditorGUILayout.LabelField("Items Preview", EditorStyles.boldLabel);

                foreach (var item in itemsDataSO.ItemsData)
                {
                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.LabelField(item.Name, GUILayout.Width(100),GUILayout.Height(50));
                    DrawSprite(item.Icon);
                    EditorGUILayout.LabelField($"Price: {item.Price.ToString(CultureInfo.InvariantCulture)}$", 
                        GUILayout.Width(100),
                    GUILayout.Height(50));
                    EditorGUILayout.EndHorizontal();
                }
            }
        }
        private void DrawSprite(UnityEngine.Sprite sprite)
        {
            Rect rect = GUILayoutUtility.GetRect(100, 100, GUILayout.Width(100), 
                GUILayout.Height(50));
            if (sprite != null)
            {
                GUI.DrawTexture(rect, sprite.texture, ScaleMode.ScaleToFit);
            }
            else
            {
                EditorGUI.LabelField(rect, "No Sprite");
            }
        }
    }
}