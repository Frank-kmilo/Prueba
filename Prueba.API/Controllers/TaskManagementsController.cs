using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Models;
using Prueba.API.Repository;

namespace Prueba.API.Controllers
{
    [Produces("aplication/json")]
    [Route("api/tasks")]
    [ApiController]
    public class TaskManagementsController : Controller
    {
        private readonly DataContext _context;

        public TaskManagementsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("index")]
        public async Task<string> Index(int UserId)
        {
            TaskManagementRepository taskManagement = new TaskManagementRepository(_context);
            List<TaskManagement> lstTaskManagement = await taskManagement.GetTask();
            return lstTaskManagement.Count != 0 ?
                        lstTaskManagement.ToJson() :
                       "[Error:] No existen tareas registradas";
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Create(TaskViewModel taskViewModel)
        {
            TaskManagement taskManagement = taskViewModelToTaskManagement(taskViewModel);
            TaskManagementRepository taskManagementRepository = new TaskManagementRepository(_context);
            return await taskManagementRepository.CreateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo crear la tarea";
        }

        [HttpPut]
        [Route("edit")]
        public async Task<string> Edit(TaskViewModel taskViewModel)
        {
            TaskManagement taskManagement = taskViewModelToTaskManagement(taskViewModel);
            TaskManagementRepository taskManagementRepository = new TaskManagementRepository(_context);
            return await taskManagementRepository.UpdateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo actualizar la tarea";
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<string> Delete(int id)
        {
            TaskManagementRepository taskManagementRepository = new TaskManagementRepository(_context);
            return await taskManagementRepository.DeleteTask(id) ? Ok().StatusCode.ToString() : "[Error:] No se pudo Eliminar la tarea";
        }

        private TaskManagement taskViewModelToTaskManagement(TaskViewModel task)
        {
            return new TaskManagement()
            {
                Id = task.Id,
                User = _context.Users.Where(x => x.Id == task.UserId).FirstOrDefault(),
                Name = task.Name,
                Description = task.Description,
                ExpirationDate = task.ExpirationDate,
                IsComplete = task.IsComplete,
            };

        }
    }
}
