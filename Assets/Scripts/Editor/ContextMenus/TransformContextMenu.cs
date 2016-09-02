using UnityEditor;
using UnityEngine;

namespace PachowStudios.BossWave.Editor.ContextMenus
{
  public static class TransformContextMenu
  {
    private const string SnapToPixelGridContextMenu = "CONTEXT/Transform/Snap to pixel grid";

    private static GameObject Target => Selection.activeGameObject;

    [MenuItem(SnapToPixelGridContextMenu)]
    public static void SnapToPixelGrid()
    {
      var transform = Target.GetComponent<Transform>();
      var sprite = Target.GetComponent<SpriteRenderer>().sprite;
      var ppu = sprite.pixelsPerUnit;

      transform.position = transform.position.TransformAll(v => Mathf.Ceil(v * ppu)).Divide(ppu);
    }

    [MenuItem(SnapToPixelGridContextMenu, true)]
    public static bool ValidateSnapToPixelGrid()
    {
      var transform = Target.GetComponent<Transform>().NullToRealNull();
      var sprite = Target.GetComponent<SpriteRenderer>().NullToRealNull()?.sprite;

      return transform != null && sprite != null;
    }
  }
}