using UnityEditor;
using UnityEngine;

public class GroundObjectEditor : EditorWindow
{
	[MenuItem("Window/GroundObject")]
	public static void SetupWindow()
	{
		var window = GetWindow<GroundObjectEditor>("GroundObject");
		window.minSize = new Vector2(400, 175);
		window.maxSize = new Vector2(window.minSize.x + 10, window.minSize.y + 10);
	}

	public void OnGUI()
	{
		if (GUILayout.Button($"Ground {Selection.transforms.Length} Objects"))
		{
		    AlignSelectedObjectsToGround();
			//foreach (Transform trans in Selection.transforms)
			//{
			//	//Undo.RecordObject(trans, $"Align With Ground: Ground Object '{trans.name}'");
			//	//SendToGround(trans);
			//}
		}

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
	private void SendToGround(Transform child, float maxCheckDistance = 100f)
	{
		Ray ray = new Ray(child.transform.position, Vector3.down);
		RaycastHit hitInfo;
		Physics.Raycast(ray, out hitInfo);

		if (hitInfo.distance < maxCheckDistance)
		{
			child.transform.position = hitInfo.point;

			if (child.transform.position == Vector3.zero)
			{
				Debug.Log(child.transform.name + "was placed out of bounds, now at 0,0,0");
			}
		}
	}

	private void AlignSelectedObjectsToGround()
    {
		foreach (var item in Selection.transforms)
        {
			RaycastHit hit;
			Ray ray = new Ray(item.transform.position, Vector3.down);
			Debug.DrawRay(item.transform.position, Vector3.down);

			Undo.RecordObject(item, $"Sending objects to ground: {item.name}");

			if (Physics.Raycast(ray, out hit))
            {
				item.transform.position = hit.point;
            }
        }
    }
}