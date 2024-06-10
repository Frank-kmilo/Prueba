using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Prueba.API.Controllers;
using Prueba.API.Data;
using Prueba.API.Data.Entities;
using Prueba.API.Helpers;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace TaskManagemenTest.Controllers
{
    [TestClass]
    public class TaskManagementTest
    {
        private readonly DbContextOptions<DataContext> _options;
        private readonly Mock<ITaskManagerHelper> _unitOfWorkMock;

        public TaskManagementTest()
        {
            _options = new DbContextOptionsBuilder<DataContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

            _unitOfWorkMock = new Mock<ITaskManagerHelper>();


        }

        [Test]
        public async Task DeleteTask_ReturnsTrue_WhenDeletionSuccessful()
        {
            // Arrange
            using DataContext context = new(_options);
            var controller = new TaskManagementsController(context);
            string result;

            // Act
            result = await controller.Delete(1);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("200", result.ToString());

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }

        [Test]
        public async Task CreateTask_Returnstrue_WhenCreationSuccessfull()
        {
            // Arrange
            using DataContext context = new(_options);
            var controller = new TaskManagementsController(context);
            string result;
            var taskManagementMock = new Mock<TaskManagement>();

            taskManagementMock.Object.Id = 1;
            taskManagementMock.Object.Name = "Tarea de ejemplo";
            taskManagementMock.Object.Description = "Descripción de la tarea de ejemplo";
            taskManagementMock.Object.ExpirationDate = DateTime.Now.AddDays(7);
            taskManagementMock.Object.IsComplete = false;
         
            // Act
            result = await controller.Create(taskManagementMock.Object);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("200", result.ToString());

            //Clean 
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
