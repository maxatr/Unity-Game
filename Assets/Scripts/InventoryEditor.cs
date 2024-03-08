using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

[CustomEditor(typeof(Inventory))]
public class InventoryEditor : Editor
{
    private Inventory _inventory;
    
    public void OnEnable()
    {
        _inventory = (Inventory) target;
    }

    public override void OnInspectorGUI()
    {
        if (_inventory.Items.Count > 0)
        {
            foreach (var item in _inventory.Items)
            {
                EditorGUILayout.BeginVertical("box");
                
                item.Id = EditorGUILayout.IntField("ID", item.Id);
                item.Name = EditorGUILayout.TextField("Name", item.Name);
                item.Image = (Sprite) EditorGUILayout.ObjectField("Image", item.Image, typeof(Sprite), false);
                
                EditorGUILayout.EndVertical();
            }
        }
        else
        {
            EditorGUILayout.LabelField("Inventory is empty");
        }

        if (GUILayout.Button("Add item", GUILayout.Width(200), GUILayout.Height(30)))
        {
            _inventory.Items.Add(new Inventory.Item());
        }

        if (GUI.changed)
        {
            SetObjectDirty(_inventory.gameObject);
        }
    }

    public static void SetObjectDirty(GameObject obj)
    {
        EditorUtility.SetDirty(obj);
        EditorSceneManager.MarkSceneDirty(obj.scene);
    }
}
