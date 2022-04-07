using Domain.Developers.Interfaces;
using Services.Developers.DTOs;

namespace Services.Developers.Interfaces;

public interface ICompanyService
{
    public ICompany GetCompany(Guid id);

    public ICompany CreateCompany(CompanyDto dto);

    public ICompany UpdateCompany(CompanyDto dto);
}