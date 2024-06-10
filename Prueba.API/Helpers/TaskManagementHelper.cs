using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using Prueba.API.Data;
using Prueba.API.Data.Entities;

namespace Prueba.API.Helpers
{
    [Authorize]
    public class TaskManagementHelper : ITaskManagerHelper
    {
        private readonly DataContext _context;

        public TaskManagementHelper(DataContext context)
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
            TaskManagement oTask = new TaskManagement();
            try
            {
                oTask = _context.TaskManagements.Where(x => x.Id == Id).FirstOrDefault();
                if (oTask != null)
                {
                    _context.Remove(oTask);
                    await _context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception ex)
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
            catch (Exception ex)
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
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
