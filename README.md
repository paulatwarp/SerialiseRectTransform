# Prefab Serialize Test

To test:

1. Select the object `Background` in the root `Assets` directory.
2. Select either `Test Without Canvas` or `Test With Canvas` from the `Modify Prefab` menu.

If you choose `Test Without Canvas` the background turns red as instructed in `Editor/UpdatePrefab.cs`, but the scale and alignment information is lost.
If you choose `Test With Canvas` the backround turns green as instructed in `Editor/UpdatePrefab.cs` and the scale and alignment information is preserved.
