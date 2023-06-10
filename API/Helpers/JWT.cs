namespace Api.Helpers;
public class JWT
{
    public string Ket { get; set; }
    public string Issuer { get; set; }
    public string Audience { get; set; }
    public double DurationInMinutes { get; set; }
}

