namespace Domain.Developers.Interfaces;

public interface IProject
{
    public Guid Id { get; set; }
    public string Name { get; set; }
}