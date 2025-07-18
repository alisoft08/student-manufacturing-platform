using eb4395u202312031.Manufacturing.Domain.Model.Queries;
using eb4395u202312031.Manufacturing.Domain.Repositories;
using eb4395u202312031.Manufacturing.Domain.Services;
using eb4395u202312031.Operations.Domain.Model.Entities;

namespace eb4395u202312031.Manufacturing.Application.Internal.QueryServices;

public class StudentQueryService(IStudentRepository Repository) : IStudentQueryService
{
    
    
    public async Task<Student?> Handle(GetStudentByStudentId query)
    {

        return await Repository.FindStudentByIdAsync(query.StudentId);


    }
}