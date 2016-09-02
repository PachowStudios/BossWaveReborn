using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace PachowStudios.BossWave.Editor.AssetPipeline
{
  public class SpriteAssetPostprocessor : AssetPostprocessor
  {
    [UsedImplicitly]
    private void OnPreprocessTexture()
    {
      if (!assetPath.Contains("Sprites"))
        return;

      var importer = (TextureImporter)assetImporter;

      importer.spritePixelsPerUnit = 16f;
      importer.filterMode = FilterMode.Point;
      importer.mipmapEnabled = false;
      importer.textureFormat = TextureImporterFormat.AutomaticTruecolor;
    }
  }
}