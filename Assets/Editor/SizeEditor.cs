using UnityEngine;
using UnityEditor;

public class SizeEditor : EditorWindow
{
	public float myString = 0;
	public float myString2 = 0;

	[MenuItem("Window/RandomSize")]
	public static void SetupWindow()
	{
		var window = GetWindow<SizeEditor>("RandomSize");
		window.minSize = new Vector2(250, 375);
		window.maxSize = new Vector2(window.minSize.x + 10, window.minSize.y + 10);
	}

	public void OnGUI()
	{
		GUILayout.Label("Choose Random Rage", EditorStyles.boldLabel);
		GUILayout.Space(20f);
		myString = EditorGUILayout.FloatField(("Random Rage"), myString);
		myString2 = EditorGUILayout.FloatField("Random Rage", myString2);
		GUILayout.Space(20f);

		if (GUILayout.Button($"Give {Selection.transforms.Length} Random Size"))
		{
			foreach (Transform trans in Selection.transforms)
			{
				Undo.RecordObject(trans, $"Align With Ground: Ground Object '{trans.name}'");
				RandomSize(trans);
			}
		}

		GUILayout.Space(20f);
		GUILayout.Label("Undo/Redo", EditorStyles.boldLabel);
		GUILayout.Space(20f);

		if (GUILayout.Button("Perform Undo"))
		{
			Undo.PerformUndo();
		}

		EditorGUILayout.Space();

		if (GUILayout.Button("Perform Redo"))
		{
			Undo.PerformRedo();
		}
	}

    private void RandomSize(Transform trans)
    {
		float randomScale = UnityEngine.Random.Range(myString, myString2);
		Transform transform = trans.GetComponent<Transform>();
		Undo.RecordObject(transform, "Changing size");

		if (transform != null)
		{
			transform.localScale = Vector3.one * randomScale;
		}
	}
}
