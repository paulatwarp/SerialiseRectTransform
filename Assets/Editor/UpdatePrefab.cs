using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public static class UpdatePrefab
{
	[MenuItem("Modify Prefab/Test Without Canvas")]
	static void TestModifyPrefabWithoutCanvas()
	{
		using (PreviewScene preview = new PreviewScene("Resources/Background"))
		{
			preview.gameObject.name = "ModifiedWithoutCanvas";
		}
	}

	[MenuItem("Modify Prefab/Test With Canvas")]
	static void TestModifyPrefabWithCanvas()
	{
		Canvas canvas = AssetDatabase.LoadAssetAtPath<Canvas>("Assets/Editor/PreviewCanvas");
		using (PreviewSceneWithCanvas preview = new PreviewSceneWithCanvas(canvas, "Resources/Background"))
		{
			preview.gameObject.name = "ModifiedWithCanvas";
		}
	}
}
