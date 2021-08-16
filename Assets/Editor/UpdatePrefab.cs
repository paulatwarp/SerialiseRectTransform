using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public static class UpdatePrefab
{
	[MenuItem("Modify Prefab/Test Without Canvas")]
	static void TestModifyPrefabWithoutCanvas()
	{
		GameObject assetRoot = Selection.activeObject as GameObject;
		if (assetRoot != null)
		{
			string path = AssetDatabase.GetAssetPath(assetRoot);
			using (PreviewScene preview = new PreviewScene(path))
			{
				Image image = preview.gameObject.GetComponent<Image>();
				image.color = Color.red;
			}
		}
		else
		{
			Debug.Log("Object not selected!");
		}
	}

	[MenuItem("Modify Prefab/Test With Canvas")]
	static void TestModifyPrefabWithCanvas()
	{
		GameObject assetRoot = Selection.activeObject as GameObject;
		if (assetRoot != null)
		{
			string path = AssetDatabase.GetAssetPath(assetRoot);
			string canvasPath = "Assets/Editor/PreviewCanvas.prefab";
			Canvas canvas = AssetDatabase.LoadAssetAtPath<Canvas>(canvasPath);
			Debug.Assert(canvas != null, $"could not load {canvasPath}");
			using (PreviewSceneWithCanvas preview = new PreviewSceneWithCanvas(canvas, path))
			{
				Image image = preview.gameObject.GetComponent<Image>();
				image.color = Color.green;
			}
		}
		else
		{
			Debug.Log("Object not selected!");
		}
	}
}
