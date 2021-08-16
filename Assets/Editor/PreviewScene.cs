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
	}

	public void Dispose()
	{
		if (gameObject != null)
		{
			bool success;
			PrefabUtility.SaveAsPrefabAsset(gameObject, path, out success);
			Debug.Assert(success);
			PrefabUtility.UnloadPrefabContents(gameObject);
		}
	}
}
