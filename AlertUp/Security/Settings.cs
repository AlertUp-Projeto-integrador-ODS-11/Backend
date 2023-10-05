namespace AlertUp.Security;

public class Settings
{
    private static string secret = "72e5720aa7789a1be945bfcc69fbf2acaa82562d1e5393446a61f9bfd3d16075";

    public static string Secret
    {
        get => secret;
        set => secret = value;
    }
}