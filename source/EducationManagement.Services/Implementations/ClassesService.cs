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
    public class ClassesService : IClassesService
    {
        private readonly IClassesRepository classesRepository;
        public ClassesService(IClassesRepository classesRepository)
        {
            this.classesRepository = classesRepository;
        }

        public async Task Delete(int id)
        {
            await classesRepository.Delete(id);
        }

        public Task<IActionResult> GenerateRandomData(int maxAmountOfParalelClasses)
        {
            return classesRepository.GeneratePrimaryData(maxAmountOfParalelClasses);
        }

        public async Task<Class> Get(int id)
        {
            return await classesRepository.Get(id);
        }
    }
}
