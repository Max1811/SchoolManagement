using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface IClassesService
    {
        public Task<IActionResult> GenerateRandomData(int maxAmountOfParalelClasses);

        public Task<Class> Get(int id);

        Task Delete(int id);
    }
}
