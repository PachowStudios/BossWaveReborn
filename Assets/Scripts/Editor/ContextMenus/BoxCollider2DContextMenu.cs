using UnityEditor;
using UnityEngine;

namespace PachowStudios.BossWave.Editor.ContextMenus
{
  public static class BoxCollider2DContextMenu
  {
    private static GameObject Target => Selection.activeGameObject;

    private const string ResizeToSpriteBorderContextMenu = "CONTEXT/BoxCollider2D/Resize to sprite border";

    [MenuItem(ResizeToSpriteBorderContextMenu)]
    public static void ResizeToSpriteBorder()
    {
      var collider = Target.GetComponent<BoxCollider2D>();
      var sprite = Target.GetComponent<SpriteRenderer>().sprite;
      var ppu = sprite.pixelsPerUnit;
      var size = sprite.bounds.size;
      var extents = sprite.border / ppu;
      var width = size.x - extents.x - extents.z;
      var height = size.y - extents.w - extents.y;
      var anchor = sprite.pivot.Divide(size) / ppu;

      collider.size = new Vector2(width, height);
      collider.offset = extents
        .ToVector2()
        .Add(collider.size / 2f)
        .Subtract(anchor.Multiply(size));
    }

    [MenuItem(ResizeToSpriteBorderContextMenu, true)]
    public static bool ValidateResizeToSpriteBorder()
    {
      var collider = Target.GetComponent<BoxCollider2D>().NullToRealNull();
      var sprite = Target.GetComponent<SpriteRenderer>().NullToRealNull()?.sprite;

      return collider != null && sprite != null && !sprite.border.IsZero();
    }
  }
}
