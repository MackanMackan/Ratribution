using UnityEngine;
using UnityEditor;

public class SizeEditor : EditorWindow
{
	public float randomOne = 0;
	public float randomTwo = 0;

	[MenuItem("Window/RandomSize")]
	public static void SetupWindow()
	{
		var window = GetWindow<SizeEditor>("RandomSize");
		window.minSize = new Vector2(250, 375);
		window.maxSize = new Vector2(window.minSize.x + 10, window.minSize.y + 10);
	}

	public void OnGUI()
	{
		GUILayout.Label("Choose Random Range", EditorStyles.boldLabel);
		GUILayout.Space(20f);
		randomOne = EditorGUILayout.FloatField(("Random Range"), randomOne);
		randomTwo = EditorGUILayout.FloatField("Random Range", randomTwo);
		GUILayout.Space(20f);

		if (GUILayout.Button($"Give {Selection.transforms.Length} Random Size"))
		{
			foreach (Transform trans in Selection.transforms)
			{
				Undo.RecordObject(trans, $"Change Size '{trans.name}'");
				RandomSize(trans);
			}
		}

		if (GUILayout.Button("Randomize Y Rotation"))
		{

			foreach (var item in Selection.transforms)
			{
				Undo.RecordObject(item, "Random rotation");
				item.transform.Rotate(item.transform.up, Random.Range(0, 359));
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
		float randomScale = UnityEngine.Random.Range(randomOne, randomTwo);
		Transform transform = trans.GetComponent<Transform>();
		Undo.RecordObject(transform, "Changing size");

		if (transform != null)
		{
			transform.localScale = Vector3.one * randomScale;
		}
	}
}
