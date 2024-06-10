using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
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
            TaskManagementRepository oTask = new TaskManagementRepository(_context);
            List<TaskManagement> tasks = await oTask.GetTask();
            return  tasks.Count != 0 ?
                        tasks.ToJson() :
                       "[Error:] No existen tareas registradas";
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Create(TaskManagement taskManagement)
        {
            TaskManagementRepository oTask = new TaskManagementRepository(_context);
            return await oTask.CreateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo crear la tarea";
        }

        [HttpPut]
        [Route("edit")]
        public async Task<string> Edit(TaskManagement taskManagement)
        {
            TaskManagementRepository oTask = new TaskManagementRepository(_context);
            return await oTask.UpdateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo actualizar la tarea";
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<string> Delete(int id)
        {
            TaskManagementRepository oTask = new TaskManagementRepository(_context);
            return await oTask.DeleteTask(id) ? Ok().StatusCode.ToString() : "[Error:] No se pudo Eliminar la tarea";
        }   
    }
}
