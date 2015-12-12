namespace UnityEngine
{
  public static class MathExtensions
  {
    public static int Sign(this float parent)
    => (int)Mathf.Sign(parent);

    public static float Abs(this float parent)
      => Mathf.Abs(parent);

    public static int RoundToInt(this float parent)
      => Mathf.RoundToInt(parent);

    public static float RoundTo(this float parent, int digit)
      => Mathf.RoundToInt(parent * digit) / (float)digit;

    public static float Clamp01(this float parent)
      => Mathf.Clamp01(parent);
  }
}