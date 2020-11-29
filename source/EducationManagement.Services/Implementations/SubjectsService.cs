using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
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

        public async Task Delete(int id)
        {
            await subjectsRepository.Delete(id);
        }

        public async Task<IActionResult> GenerateRandomData(int subjectsCount)
        {
            return await subjectsRepository.GeneratePrimaryData(subjectsCount);
        }

        public async Task<Subject> Get(int id)
        {
            return await subjectsRepository.Get(id);
        }

        public async Task<IEnumerable<Subject>> GetAllAsync()
        {
            return await subjectsRepository.GetAllAsync();
        }
    }
}
