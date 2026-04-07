using System;

class LegacyAPI
{
    [Obsolete("OldFeature is deprecated. Use NewFeature instead.")]
    public void OldFeature()
    {
        Console.WriteLine("Executing old feature");
    }

    public void NewFeature()
    {
        Console.WriteLine("Executing new feature");
    }
}

class ObsoleteAttribute
{
    static void Main()
    {
        LegacyAPI api = new LegacyAPI();

        api.OldFeature();   // Compiler will show a warning
        api.NewFeature();   // Recommended method
    }
}
