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
		Debug.Assert(prefab != null, $"could not load asset at {path}");
		RectTransform rectTransform = prefab.GetComponentInChildren<RectTransform>();
		if (rectTransform != null)
		{
			string canvasPath = AssetDatabase.GetAssetPath(canvasPrefab);
			Debug.Assert(canvasPath != null, $"could not find path to {canvasPrefab}");
			content = PrefabUtility.LoadPrefabContents(canvasPath);
			Debug.Assert(content != null, $"could not load {canvasPrefab}");
			gameObject = PrefabUtility.InstantiatePrefab(prefab, content.transform) as GameObject;
			Debug.Assert(gameObject != null, $"could not instantiate prefab {path}");
		}
		else
		{
			gameObject = PrefabUtility.LoadPrefabContents(path);
			Debug.Assert(gameObject != null, $"could not load {path}");
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
			if (success)
			{
				Debug.Log($"Successfully modified {path}");
			}
		}
		if (content != null)
		{
			PrefabUtility.UnloadPrefabContents(content);
		}
	}
}
