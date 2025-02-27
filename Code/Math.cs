public class Math
{
    public const float pi = 3.14159274;
    public static float SquareRoot(float number)
    {
        // Newton's Method
        float accuracy = 1e-6f; // 10^-6, or the function is accurate to 6 decimal places
        float prevApprox; // Used to calculate if it is close to the tolerance
        float approx;
     
        if(number == 0)
           return 0;
        else if(number < 1)
          approx = 1;
        else
           approx = number / 2;

         // This function will return a square root with an accuracy to 6 decimal places, however if that isn't possible or we don't reach that after 100 iterations, it'll just return what it has. This ensures that we don't get stuck in an infinite loop
        for(int i = 0; i < 100; i++)
        {
            prevApprox = approx;
            approx = 0.5f * (approx + (number/approx));
            if(AbsoluteValue(approx - prevApprox) < accuracy)
              return approx;
        }
        return approx;
    }

    public static float AbsoluteValue(float number)
    {
        // If the number is negative, return the number multiplied by -1 (which makes it positive)
        if(number < 0)
         return -number;
        // Else just return the number
        return number;
    }

    // Returns cosine in Radians
    public static float CosineRad(float value)
    {
        // Using taylor's series, will be accurate to decimal places
        return 1 - ((value * value) / 2) + ((value * value * value * value) / 24) - ((value * value * value * value * value * value) / 720);
    }
    
    // Returns cosine in Degrees
    public static float CosineDeg(float value)
    {
        value = value * (pi / 180);
        // Using taylor's series, will be accurate to decimal places
        return (180 / pi) * (1 - ((value * value) / 2) + ((value * value * value * value) / 24) - ((value * value * value * value * value * value) / 720));
    }

    // Returns sine in Radians
    public static float SineRad(float value)
    {
        // Using taylor's series, will be accurate to decimal places
        return value - ((value * value * value)/6) + ((value * value * value * value * value) / 120) - ((value * value * value * value * value * value * value) / 5040);
    }
    
        // Returns sine in Degrees
    public static float SineDeg(float value)
    {
        value = value * (pi / 180);
        // Using taylor's series, will be accurate to decimal places
        return (180 / pi) * (value - ((value * value * value)/6) + ((value * value * value * value * value) / 120) - ((value * value * value * value * value * value * value) / 5040));
    }

    public static float ArccosineDeg(float value)
    {
        // Newton's Method
        float accuracy = 1e-6f; // 10^-6, or the function is accurate to 6 decimal places
        float prevApprox; // Used to calculate if it is close to the tolerance
        float approx = 1;

        for(int i = 0; i < 100; i++) 
        {
            prevApprox = approx;
            approx = approx + CosineDeg(approx) / -SineDeg(approx);
            if (AbsoluteValue(approx - prevApprox) < accuracy)
                return approx;
        }

        return approx;
    }
}
