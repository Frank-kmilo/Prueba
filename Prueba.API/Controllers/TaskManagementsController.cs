﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;

namespace Prueba.API.Controllers
{
    [Produces("aplication/json")]
    [ApiController]
    [Route("api/task")]
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
            TaskManagementHelper oTask = new TaskManagementHelper(_context);
            List<TaskManagement> tasks = await oTask.GetTask();
            return  tasks.Count != 0 ?
                        tasks.ToJson() :
                       "[Error:] No existen tareas registradas";
        }

        [HttpPost]
        [Route("create")]
        public async Task<string> Create(TaskManagement taskManagement)
        {
            TaskManagementHelper oTask = new TaskManagementHelper(_context);
            return await oTask.CreateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo crear la tarea";
        }

        [HttpPut]
        [Route("edit")]
        public async Task<string> Edit(TaskManagement taskManagement)
        {
            TaskManagementHelper oTask = new TaskManagementHelper(_context);
            return await oTask.UpdateTask(taskManagement) ? Ok().StatusCode.ToString() : "[Error:] No se pudo actualizar la tarea";
        }

        [HttpDelete]
        [Route("delete/{id}")]
        public async Task<string> Delete(int id)
        {
            TaskManagementHelper oTask = new TaskManagementHelper(_context);
            return await oTask.DeleteTask(id) ? Ok().StatusCode.ToString() : "[Error:] No se pudo Eliminar la tarea";
        }   
    }
}
