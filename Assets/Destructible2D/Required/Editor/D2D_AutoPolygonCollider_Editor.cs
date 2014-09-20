using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(D2D_AutoPolygonCollider))]
public class D2D_AutoPolygonCollider_Editor : D2D_Editor<D2D_AutoPolygonCollider>
{
	protected override void OnInspector()
	{
		EditorGUILayout.HelpBox("This component will use Unity's built-in PolygonCollider2D generation.", MessageType.Info);
	}
}