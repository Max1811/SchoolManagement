using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducationManagement.Services.Implementations
{
    public class SubjectsService : ISubjectsService
    {
        private readonly ISubjectsRepository subjectsRepository;

        public SubjectsService(ISubjectsRepository subjectsRepository)
        {
            this.subjectsRepository = subjectsRepository;
        }

        public async Task<IActionResult> GenerateRandomData(int subjectsCount)
        {
            return await subjectsRepository.GeneratePrimaryData(subjectsCount);
        }
    }
}
