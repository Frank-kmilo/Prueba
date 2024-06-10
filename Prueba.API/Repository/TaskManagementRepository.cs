using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;

namespace Prueba.API.Repository
{
    public class TaskManagementRepository : ITaskManagerHelper
    {
        private readonly DataContext _context;

        public TaskManagementRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<TaskManagement>> GetTask()
        {
            return await _context.TaskManagements.ToListAsync();
        }

        public async Task<TaskManagement> GetTask(int Id)
        {
            return await _context.TaskManagements.FindAsync(Id);
        }

        public async Task<bool> DeleteTask(int Id)
        {
            TaskManagement task = new();
            try
            {
                task = _context.TaskManagements.Where(x => x.Id == Id).FirstOrDefault();
                if (task != null)
                {
                    _context.Remove(task);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> CreateTask(TaskManagement taskManagement)
        {
            try
            {
                _context.TaskManagements.Add(taskManagement);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public async Task<bool> UpdateTask(TaskManagement taskManagement)
        {
            try
            {
                TaskManagement newTask = await _context.TaskManagements.Where(x => x.Id == taskManagement.Id).FirstOrDefaultAsync();

                newTask.Name = taskManagement.Name;
                newTask.Description = taskManagement.Description;
                newTask.IsComplete = taskManagement.IsComplete;

                _ = _context.Update(newTask);
                _ = await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
