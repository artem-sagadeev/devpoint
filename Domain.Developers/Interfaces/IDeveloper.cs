namespace Domain.Developers.Interfaces;

public interface IDeveloper
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}