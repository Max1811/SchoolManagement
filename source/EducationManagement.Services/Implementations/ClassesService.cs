using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
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

        public Task<IActionResult> GenerateRandomData(int maxAmountOfParalelClasses)
        {
            return classesRepository.GeneratePrimaryData(maxAmountOfParalelClasses);
        }
    }
}
