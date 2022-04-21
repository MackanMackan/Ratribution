using UnityEngine;
using UnityEditor;
using System;

public class ColliderEditor : EditorWindow
{
    [MenuItem("Window/ColliderEditor")]
	public static void SetupWindow()
	{
		var window = GetWindow<ColliderEditor>("ColliderEditor");
		window.minSize = new Vector2(400, 175);
		window.maxSize = new Vector2(window.minSize.x + 10, window.minSize.y + 10);
	}

	public void OnGUI()
	{
		if (GUILayout.Button($"Ground {Selection.transforms.Length} Objects"))
		{
			foreach (GameObject game in Selection.gameObjects)
			{
				//Undo.RecordObject(game, $"Align With Ground: Ground Object '{game.name}'");
				ShowCollider(game);
			}
		}
	}

    private void ShowCollider(GameObject game)
    {
		Collider collider = game.GetComponent<Collider>();
		//Undo.RecordObject(renderer, "Changing Color");

		if (collider != null)
		{
			
		}
	}
}
