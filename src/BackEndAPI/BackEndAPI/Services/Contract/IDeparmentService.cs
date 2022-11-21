using BackEndAPI.Models;

namespace BackEndAPI.Services.Contract
{
    public interface IDeparmentService
    {
        Task<List<Department>> GetList();
    }
}
