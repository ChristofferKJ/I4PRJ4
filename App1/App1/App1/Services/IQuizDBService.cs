using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using App1.Model;

namespace App1.Services
{
    public interface IQuizDBService
    {
       Task<List<Quiz>> GetAllQuizzesAsync();

        Task<List<Quiz>> GetQuizzesByCategoryAsync(string category);
    }
}
