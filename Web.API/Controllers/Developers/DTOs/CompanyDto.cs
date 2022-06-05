using Domain.Developers.Entities;

namespace Web.API.Controllers.Developers.DTOs;

public class CompanyDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public decimal? Latitude { get; set; }
    public decimal? Longitude { get; set; }

    public CompanyDto(Company company)
    {
        Id = company.Id;
        Name = company.Name;
        Latitude = company.Latitude;
        Longitude = company.Longitude;
    }
}