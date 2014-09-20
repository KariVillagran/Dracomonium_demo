using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(D2D_PolygonColliders))]
public class D2D_PolygonColliders_Editor : D2D_Editor<D2D_PolygonColliders>
{
	private static bool hideColliders;
	
	protected override void OnInspector()
	{
		EditorGUI.BeginChangeCheck();
		{
			DrawDefault("CellSize");
			DrawDefault("Tolerance");
		}
		if (EditorGUI.EndChangeCheck() == true)
		{
			foreach (var t in Targets)
			{
				if (t != null)
				{
					var destructible = D2D_Helper.GetComponentUpwards<D2D_Destructible>(t.transform);
					
					if (destructible != null)
					{
						t.RebuildAllColliders(destructible.AlphaTex);
					}
				}
			}
		}
		
		EditorGUILayout.Separator();
		
		hideColliders = EditorGUILayout.Toggle("Hide Colliders", hideColliders);
		
		foreach (var t in Targets)
		{
			t.SetHideFlags(hideColliders == true ? HideFlags.HideInInspector : HideFlags.None);
		}
	}
}