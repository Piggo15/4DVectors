namespace _4DVectors.Code;

public class Vector4
{
    // Basic proproties
    public float X { get; private set; }
    public float Y { get; private set; }
    public float Z { get; private set; }
    public float W { get; private set; }

    // Advanced proproties
    public float Magnitude { get; private set; }
    public Vector4 Normalized { get; private set; }

    // Constructors
    public Vector4(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;

        Magnitude = Math.SquareRoot(x * x + y * y + z * z + w * w);

        Normalized = SafeCompare(Magnitude, 1)
            ? this
            : new Vector4(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude);
    }

    public Vector4()
        : this(0f, 0f, 0f, 0f)
    {
    }

    // Static proproties

    // Public methods

    public bool Equals(Vector4 comparedVector)
        => SafeCompare(X, comparedVector.X) &&
           SafeCompare(Y, comparedVector.Y) &&
           SafeCompare(Z, comparedVector.Z) &&
           SafeCompare(W, comparedVector.W);

    public override string ToString()
    {
        return "[" + X + ", " + Y + ", " + Z + ", " + W + "]";
    }

    public void Set(float x, float y, float z, float w)
    {
        X = x;
        Y = y;
        Z = z;
        W = w;

        Magnitude = Math.SquareRoot(x * x + y * y + z * z + w * w);

        Normalized =
            SafeCompare(Magnitude, 1)
                ? this
                : new Vector4(x / Magnitude, y / Magnitude, z / Magnitude, w / Magnitude);
    }

    // Static methods

    public static float Angle(Vector4 firstVector, Vector4 secondVector)
    {
        // Angle in degrees
        var cos = Dot(firstVector, secondVector) / (firstVector.Magnitude * secondVector.Magnitude);
        return Math.ArccosineDeg(cos);
    }

    public static Vector4 ClampMagnitude(Vector4 vector, float maxMagnitude)
    {
        if (vector.Magnitude <= maxMagnitude)
            return vector;

        return new Vector4(vector.Normalized.X * maxMagnitude, vector.Normalized.Y * maxMagnitude,
            vector.Normalized.Z * maxMagnitude, vector.Normalized.W * maxMagnitude);
    }

    public static float Dot(Vector4 firstVector, Vector4 secondVector)
    {
        return firstVector.X * secondVector.X + firstVector.Y * secondVector.Y + firstVector.Z * secondVector.Z +
               firstVector.W * secondVector.W;
    }

    public static float Distance(Vector4 firstVector, Vector4 secondVector)
    {
        return Math.SquareRoot((firstVector.X - secondVector.X) * (firstVector.X - secondVector.X) +
                               (firstVector.Y - secondVector.Y) * (firstVector.Y - secondVector.Y) +
                               (firstVector.Z - secondVector.Z) * (firstVector.Z - secondVector.Z) +
                               (firstVector.W - secondVector.W) * (firstVector.W - secondVector.W));
    }

    public static Vector4 Max(Vector4 firstVector, Vector4 secondVector)
    {
        var x = firstVector.X > secondVector.X ? firstVector.X : secondVector.X;
        var y = firstVector.Y > secondVector.Y ? firstVector.Y : secondVector.Y;
        var z = firstVector.Z > secondVector.Z ? firstVector.Z : secondVector.Z;
        var w = firstVector.W > secondVector.W ? firstVector.W : secondVector.W;

        return new Vector4(x, y, z, w);
    }

    public static Vector4 Min(Vector4 firstVector, Vector4 secondVector)
    {
        var x = firstVector.X < secondVector.X ? firstVector.X : secondVector.X;
        var y = firstVector.Y < secondVector.Y ? firstVector.Y : secondVector.Y;
        var z = firstVector.Z < secondVector.Z ? firstVector.Z : secondVector.Z;
        var w = firstVector.W < secondVector.W ? firstVector.W : secondVector.W;

        return new Vector4(x, y, z, w);
    }

    // Operators
    public static Vector4 operator +(Vector4 firstVector, Vector4 secondVector)
    {
        return new Vector4(firstVector.X + secondVector.X, firstVector.Y + secondVector.Y,
            firstVector.Z + secondVector.Z, firstVector.W + secondVector.W);
    }

    public static Vector4 operator -(Vector4 firstVector, Vector4 secondVector)
    {
        return new Vector4(firstVector.X - secondVector.X, firstVector.Y - secondVector.Y,
            firstVector.Z - secondVector.Z, firstVector.W - secondVector.W);
    }

    private static bool SafeCompare(float a, float b, float tolerance = 0.1f)
        => System.Math.Abs(a - b) < tolerance;
}