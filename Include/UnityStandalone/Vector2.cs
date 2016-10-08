/*
 *  Standalone Unity shim for external-to-unity functionality.
*/

namespace UnityStandalone
{
  public struct Vector2
  {
    public static Vector2 zero { get { return new Vector2(0.0f, 0.0f); } }

    public static float Dot(Vector2 a, Vector2 b)
    {
      return (a.x * b.x) + (a.y * b.y);
    }

    public readonly float x;
    public readonly float y;

    public float sqrMagnitude
    {
      get
      {
        return (this.x * this.x) + (this.y * this.y);
      }
    }

    public float magnitude
    {
      get
      {
        return Mathf.Sqrt(this.sqrMagnitude);
      }
    }

    public Vector2 normalized
    {
      get
      {
        float magnitude = this.magnitude;
        return new Vector2(this.x / magnitude, this.y / magnitude);
      }
    }

    public Vector2(float x, float y)
    {
      this.x = x;
      this.y = y;
    }

    public static Vector2 operator *(Vector2 a, float b)
    {
      return new Vector2(a.x * b, a.y * b);
    }

    public static Vector2 operator *(float a, Vector2 b)
    {
      return new Vector2(b.x * a, b.y * a);
    }

    public static Vector2 operator +(Vector2 a, Vector2 b)
    {
      return new Vector2(a.x + b.x, a.y + b.y);
    }

    public static Vector2 operator -(Vector2 a, Vector2 b)
    {
      return new Vector2(a.x - b.x, a.y - b.y);
    }

    public static Vector2 operator -(Vector2 a)
    {
      return new Vector2(-a.x, -a.y);
    }
  }
}