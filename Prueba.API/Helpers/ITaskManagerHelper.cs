using Prueba.API.Data.Entities;

namespace Prueba.API.Helpers
{
    public interface ITaskManagerHelper
    {
        Task<List<TaskManagement>> GetTask();
        Task<TaskManagement> GetTask(int Id);
        Task<bool> DeleteTask(int Id);
        Task<bool> CreateTask(TaskManagement taskManagement);
        Task<bool> UpdateTask(TaskManagement taskManagement);
    }
}
