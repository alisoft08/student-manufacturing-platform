using eb4395u202312031.Manufacturing.Domain.Model.Queries;
using eb4395u202312031.Operations.Domain.Model.Entities;

namespace eb4395u202312031.Manufacturing.Domain.Services;

public interface IStudentQueryService
{
    Task<Student?> Handle(GetStudentByStudentId query);
}