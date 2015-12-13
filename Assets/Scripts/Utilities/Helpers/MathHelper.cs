using UnityEngine;

namespace LudumDare34
{
  public static class MathHelper
  {
    public static int RandomSign()
      => Random.value < 0.5f ? -1 : 1;
  }
}