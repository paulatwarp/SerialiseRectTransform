using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PreviewSceneWithCanvas : System.IDisposable
{
	public string path;
	public GameObject gameObject;
	GameObject content;

	public PreviewSceneWithCanvas(Canvas canvasPrefab, string path)
	{
		this.path = path;
		GameObject prefab = AssetDatabase.LoadAssetAtPath<GameObject>(path);
		RectTransform rectTransform = prefab.GetComponentInChildren<RectTransform>();
		if (rectTransform != null)
		{
			string canvasPath = AssetDatabase.GetAssetPath(canvasPrefab);
			content = PrefabUtility.LoadPrefabContents(canvasPath);
			gameObject = PrefabUtility.InstantiatePrefab(prefab, content.transform) as GameObject;
		}
		else
		{
			gameObject = PrefabUtility.LoadPrefabContents(path);
			content = gameObject;
		}
	}

	public void Dispose()
	{
		if (gameObject != null)
		{
			bool success;
			PrefabUtility.SaveAsPrefabAsset(gameObject, path, out success);
			Debug.Assert(success);
			PrefabUtility.UnloadPrefabContents(content);
		}
	}
}
