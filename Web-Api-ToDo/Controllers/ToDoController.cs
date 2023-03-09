using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Web_Api_ToDo.Models;
using Web_Api_ToDo.Repositorio;

namespace Web_Api_ToDo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ToDoController : ControllerBase
    {
        private ToDoService ToDoService { get; set; }
        public ToDoController(ToDoService _toDoService)
        {
            ToDoService = _toDoService;
        }

        [HttpGet("[action]")]
        public IActionResult getAll()
        {
            var allToDo = ToDoService.GetAllToDo();

            if (allToDo.Any())
                return Ok(new { data = allToDo });

            return NoContent();
        }

        [HttpGet("[action]/{id}")]
        public IActionResult getById(int id)
        {
            var toDo = ToDoService.GetToDoById(id);

            if (toDo != null)
                return Ok(new { data = toDo });

            return NoContent();
        }

        [HttpPost("[action]")]
        public IActionResult Post(ToDo toDo)
        {
            ToDoService.AddToDo(toDo);

            return Ok(new { message = "Tarefa criada com sucesso!" });
        }

        [HttpPost("[action]/{id}")]
        public IActionResult ConcluirToDo(int id)
        {
            var toDo = ToDoService.GetToDoById(id);

            if (toDo != null)
            {
                toDo.ConcluirTarefa();

                ToDoService.UpdateToDo(toDo);

                return Ok(new { data = toDo });
            }

            return NoContent();
        }

        [HttpDelete("[action]/{id}")]
        public IActionResult Delete(int id)
        {
            var todo = ToDoService.GetToDoById(id);

            if (todo != null)
            {
                ToDoService.DeleteToDo(todo);

                return Ok(new { message = "Tarefa excluida com sucesso!" });
            }

            return BadRequest(new { message = "Erro ao buscar tarefa." });
        }

    }
}
