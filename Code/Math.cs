namespace _4DVectors.Code;

public class Math
{
    public static float SquareRoot(float number)
    {
        // Newton's Method
        var accuracy = 1e-6f; // 10^-6, or the function is accurate to 6 decimal places
        float prevApprox; // Used to calculate if it is close to the tolerance
        float approx;

        if (number == 0)
            return 0;
        if (number < 1)
            approx = 1;
        else
            approx = number / 2;

        // This function will return a square root with an accuracy to 6 decimal places, however if that isn't possible or we don't reach that after 100 iterations, it'll just return what it has. This ensures that we don't get stuck in an infinite loop
        for (var i = 0; i < 100; i++)
        {
            prevApprox = approx;
            approx = 0.5f * (approx + number / approx);
            if (AbsoluteValue(approx - prevApprox) < accuracy)
                return approx;
        }

        return approx;
    }

    public static float AbsoluteValue(float number)
    {
        // If the number is negative, return the number multiplied by -1 (which makes it positive)
        if (number < 0)
            return -number;
        // Else just return the number
        return number;
    }

    // Returns cosine in Radians
    public static float CosineRad(float value)
    {
        // Using Taylor's Series, will be accurate to about 7 decimal places
        float term = 1;
        float result = 1;

        for (var i = 1; i < 100; i++)
        {
            term *= -value * value / ((2 * i - 1) * (2 * i));
            result += term;

            if (AbsoluteValue(term) < 1e-6f)
                return result;
        }

        return result;
    }

    // Returns cosine in Degrees
    public static float CosineDeg(float value)
    {
        value *= (float.Pi / 180);
        // Using Taylor's Series, will be accurate to about 7 decimal places
        float term = 1;
        float result = 1;

        for (var i = 1; i < 100; i++)
        {
            term *= -value * value / ((2 * i - 1) * (2 * i));
            result += term;

            if (AbsoluteValue(term) < 1e-6f)
                return result;
        }

        return result;
    }

    // Returns sine in Radians
    public static float SineRad(float value)
    {
        // Using Taylor's Series, will be accurate to about 7 decimal places
        float term = value;
        float result = value;

        for (var i = 1; i < 100; i++)
        {
            term *= -value * value / ((2 * i) * (2 * i + 1));
            result += term;

            if (AbsoluteValue(term) < 1e-6f)
                return result;
        }

        return result;
    }

    // Returns sine in Degrees
    public static float SineDeg(float value)
    {
        value *= (float.Pi / 180);
        // Using Taylor's Series, will be accurate to about 7 decimal places
        float term = value;
        float result = value;
        
        for (var i = 1; i < 100; i++)
        {
            term *= -value * value / ((2 * i) * (2 * i + 1));
            result += term;

            if (AbsoluteValue(term) < 1e-6f)
                return result;
        }

        return result;
    }

    // Returns Arccosine in Radians
    public static float ArccosineRad(float value)
    {
        if (value > 1 || value < -1)
            throw new System.ArgumentOutOfRangeException("value", "The input for Arccosine (value) must be between -1 and 1!")

        // Newton's Method
        var accuracy = 1e-6f; // 10^-6, or the function is accurate to 6 decimal places
        float prevApprox; // Used to calculate if it is close to the tolerance
        float approx = (float.Pi / 2);

        for (var i = 0; i < 1000; i++)
        {
            prevApprox = approx;
            approx -= (CosineRad(approx) - value) / -SineRad(approx);
            if (AbsoluteValue(approx - prevApprox) < accuracy)
                return approx;
        }

        return approx;
    }

    // Returns Arccosine in Degrees
    public static float ArccosineDeg(float value)
    {
        if (value > 1 || value < -1)
            throw new System.ArgumentOutOfRangeException("value", "The input for Arccosine (value) must be between -1 and 1!")
        
        // Newton's Method
        var accuracy = 1e-6f; // 10^-6, or the function is accurate to 6 decimal places
        float prevApprox; // Used to calculate if it is close to the tolerance
        float approx = value < 0.5f ? 90f : 1f;

        for (var i = 0; i < 1000; i++)
        {
            prevApprox = approx;
            approx -= (CosineDeg(approx) - value) / -SineDeg(approx);
            if (AbsoluteValue(approx - prevApprox) < accuracy)
                return approx;
        }

        return approx;
    }
}
