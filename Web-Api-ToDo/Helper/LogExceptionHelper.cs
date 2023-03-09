using System.IO;
using System;
using System.Threading.Tasks;
using Web_Api_ToDo.Models;

namespace Web_Api_ToDo.Helper
{
    public class LogExceptionHelper
    {
        public static async Task SaveLogException(ErrorResponseMiddleware model)
        {
            string fileName = Path.Combine(new[] { Environment.CurrentDirectory, "LogException", $"{model.Id}.txt" });

            var fi = new FileInfo(fileName);

            using (StreamWriter sw = fi.CreateText())
            {
                await sw.WriteLineAsync($"Id = {model.Id}.");
                await sw.WriteLineAsync($"Data = {model.Data}.");
                await sw.WriteLineAsync($"ExceptionType = {model.ExceptionType}.");
                await sw.WriteLineAsync($"StatusCode = {model.StatusCode}.");
                await sw.WriteLineAsync($"Mensagem = {model.Mensagem}.");
                await sw.WriteLineAsync($"StackTrace = \"{model.StackTrace}\".");
            }

        }
    }
}
