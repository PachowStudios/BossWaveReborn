using JetBrains.Annotations;
using UnityEditor;
using UnityEngine;

namespace PachowStudios.BossWave.Editor
{
  public class SpriteAssetPostprocessor : AssetPostprocessor
  {
    [UsedImplicitly]
    private void OnPostprocessSprites(Texture2D texture, Sprite[] sprites)
    {
      var importer = assetImporter as TextureImporter;

      if (importer == null)
        return;

      importer.spritePixelsPerUnit = 16f;
      importer.filterMode = FilterMode.Point;
      importer.mipmapEnabled = false;
      importer.textureFormat = TextureImporterFormat.AutomaticTruecolor;
    }
  }
}