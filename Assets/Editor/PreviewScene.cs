using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PreviewScene : System.IDisposable
{
	public string path;
	public GameObject gameObject;

	public PreviewScene(string path)
	{
		this.path = path;
		gameObject = PrefabUtility.LoadPrefabContents(path);
		Debug.Assert(gameObject != null, $"could not load {path}");
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
			PrefabUtility.UnloadPrefabContents(gameObject);
		}
	}
}
