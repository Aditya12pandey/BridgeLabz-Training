using System;

public class OTPGenerator
{
    public static int GenerateOTP()
    {
        Random random = new Random();
        // Generates a 6-digit number between 100000 and 999999
        return random.Next(100000, 1000000);
    }

    public static bool AreOTPsUnique(int[] otps)
    {
        for (int i = 0; i < otps.Length; i++)
        {
            for (int j = i + 1; j < otps.Length; j++)
            {
                if (otps[i] == otps[j])
                {
                    return false; // duplicate found
                }
            }
        }
        return true; // all unique
    }

    public static void Main(string[] args)
    {
        int[] otpArray = new int[10];

        for (int i = 0; i < otpArray.Length; i++)
        {
            otpArray[i] = GenerateOTP();
            Console.WriteLine($"Generated OTP {i + 1}: {otpArray[i]}");
        }

        bool isUnique = AreOTPsUnique(otpArray);

        Console.WriteLine("\nAre all OTPs unique? " + isUnique);
    }
}
