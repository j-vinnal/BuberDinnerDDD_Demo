namespace BuberDinner.Infrastructure.Appsettings;

public class NpgsqlSettings
{
    public const string SectionName = "ConnectionStrings";
    public string DefaultConnection { get; set; } = default!;
}