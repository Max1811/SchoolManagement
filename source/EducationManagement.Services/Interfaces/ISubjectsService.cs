using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface ISubjectsService
    {
        public Task<IActionResult> GenerateRandomData(int subjectsCount);
    }
}
