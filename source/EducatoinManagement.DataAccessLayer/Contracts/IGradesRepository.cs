using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IGradesRepository
    {
        public Task<IActionResult> GeneratePrimaryData(int lowerBound, int upperBound, int numberOfGradesPerStudent);
    }
}
