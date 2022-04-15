using Domain.Developers.Interfaces;
using Services.Developers.DTOs;

namespace Services.Developers.Interfaces;

public interface ICompanyService
{
    public Task<ICompany> GetCompany(Guid id);

    public Task<ICompany> CreateCompany(CompanyDto dto);

    public Task<ICompany> UpdateCompany(CompanyDto dto);
}