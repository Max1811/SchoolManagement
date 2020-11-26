using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface IGradesService
    {
        public Task<IActionResult> GenerateRandomData(int lowerBound, int upperBound, int numberOfGradesPerStudent);
    }
}
