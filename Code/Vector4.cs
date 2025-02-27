public class Vector4
{
    // Basic proproties
  
    public float x {get; private set;}
    public float y {get; private set;}
    public float z {get; private set;}
    public float w {get; private set;}

    // Advanced proproties
  
    public float magnitude {get; private set;}
    public Vector4 normalized {get; private set;}

    // Constructors
  
    public Vector4(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;

        this.magnitude = Math.SquareRoot((x*x)+(y*y)+(z*z)+(w*w));
     
        if(magnitude == 1)
            this.normalized = this;
        else
            this.normalized = new Vector4(x/magnitude, y/magnitude, z/magnitude, w/magnitude);
    }
  
    public Vector4()
    {
        this.x = 0;
        this.y = 0;
        this.z = 0;
        this.w = 0;

        this.magnitude = Math.SquareRoot((x*x)+(y*y)+(z*z)+(w*w));
     
        if(magnitude == 1)
            this.normalized = this;
        else
            this.normalized = new Vector4(x/magnitude, y/magnitude, z/magnitude, w/magnitude);
    }
  
    // Static proproties
  
    // Public methods
  
    public bool Equals(Vector4 comparedVector)
    {
        if(this.x == comparedVector.x && this.y == comparedVector.y && this.z == comparedVector.z && this.w == comparedVector.w)
            return true;
     
        return false;
    }

    public override string ToString()
    {
        return "[" + this.x + ", " + this.y + ", " + this.z + ", " + this.w + "]";
    }

    public void Set(float x, float y, float z, float w)
    {
        this.x = x;
        this.y = y;
        this.z = z;
        this.w = w;

        this.magnitude = Math.SquareRoot((x*x)+(y*y)+(z*z)+(w*w));
     
        if(magnitude == 1)
            this.normalized = this;
        else
            this.normalized = new Vector4(x/magnitude, y/magnitude, z/magnitude, w/magnitude);
    }
  
    // Static methods

    public static float Angle(Vector4 firstVector, Vector4 secondVector)
    {
        // Angle in degrees
        float cos = Dot(firstVector, secondVector) / (firstVector.magnitude * secondVector.magnitude);
        return Math.ArccosineDeg(cos);
    }

    public static Vector4 ClampMagnitude(Vector4 vector, float maxMagnitude)
    {
      if(vector.magnitude <= maxMagnitude)
       return vector;

      return new Vector4(vector.normalized.x * maxMagnitude, vector.normalized.y * maxMagnitude, vector.normalized.z * maxMagnitude, vector.normalized.w * maxMagnitude);
    }

    public static float Dot(Vector4 firstVector, Vector4 secondVector)
    {
        return (firstVector.x * secondVector.x) + (firstVector.y * secondVector.y) + (firstVector.z * secondVector.z) + (firstVector.w * secondVector.w);
    }

    public static float Distance(Vector4 firstVector, Vector4 secondVector)
    {
      return Math.SquareRoot(((firstVector.x - secondVector.x) * (firstVector.x - secondVector.x)) + ((firstVector.y - secondVector.y) * (firstVector.y - secondVector.y)) + ((firstVector.z - secondVector.z) * (firstVector.z - secondVector.z)) + ((firstVector.w - secondVector.w) * (firstVector.w - secondVector.w)));
    }

    public static Vector4 Max(Vector4 firstVector, Vector4 secondVector)
    {
      float x;
      float y;
      float z;
      float w;
     
      if(firstVector.x > secondVector.x)
       x = firstVector.x;
      else
       x = secondVector.x;
     
      if(firstVector.y > secondVector.y)
       x = firstVector.y;
      else
       x = secondVector.y;
     
      if(firstVector.z > secondVector.z)
       x = firstVector.z;
      else
       x = secondVector.z;
     
      if(firstVector.w > secondVector.w)
       x = firstVector.w;
      else
       x = secondVector.w;

      return new Vector4(x, y, z, w);
    }

    public static Vector4 Min(Vector4 firstVector, Vector4 secondVector)
    {
      float x;
      float y;
      float z;
      float w;
     
      if(firstVector.x < secondVector.x)
       x = firstVector.x;
      else
       x = secondVector.x;
     
      if(firstVector.y < secondVector.y)
       x = firstVector.y;
      else
       x = secondVector.y;
     
      if(firstVector.z < secondVector.z)
       x = firstVector.z;
      else
       x = secondVector.z;
     
      if(firstVector.w < secondVector.w)
       x = firstVector.w;
      else
       x = secondVector.w;

      return new Vector4(x, y, z, w);
    }

    // Operators

    public static Vector4 operator +(Vector4 firstVector, Vector4 secondVector)
    {
        return new Vector4(firstVector.x + secondVector.x, firstVector.y + secondVector.y, firstVector.z + secondVector.z, firstVector.w + secondVector.w);
    }
  
    public static Vector4 operator -(Vector4 firstVector, Vector4 secondVector)
    {
        return new Vector4(firstVector.x - secondVector.x, firstVector.y - secondVector.y, firstVector.z - secondVector.z, firstVector.w - secondVector.w);
    }
}
