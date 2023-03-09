using System.Collections.Generic;
using System.Linq;
using Web_Api_ToDo.Models;
using System;
using Web_Api_ToDo.Exceptions;

namespace Web_Api_ToDo.Repositorio
{
    public class ToDoService
    {
        private ToDoDBContext DBContext { get; set; }
        public ToDoService(ToDoDBContext _dBContext)
        {
            DBContext = _dBContext;
        }

        public void AddToDo(ToDo toDo)
        {
            try
            {
                DBContext.Add<ToDo>(toDo);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbContextException(ex.Message);
            }
        }

        public List<ToDo> GetAllToDo()
        {
            try
            {
                return DBContext.ToDo.ToList();

            }
            catch (Exception ex)
            {
                throw new DbContextException(ex.Message);
            }
        }

        public ToDo GetToDoById(int id)
        {
            try
            {
                return DBContext.ToDo.Find(id);

            }
            catch (Exception ex)
            {
                throw new DbContextException(ex.Message);
            }
        }

        public void UpdateToDo(ToDo toDo)
        {
            try
            {
                DBContext.Update<ToDo>(toDo);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbContextException(ex.Message);
            }
        }

        public void DeleteToDo(ToDo toDo)
        {
            try
            {
                DBContext.Remove<ToDo>(toDo);
                DBContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new DbContextException(ex.Message);
            }
        }
    }
}
