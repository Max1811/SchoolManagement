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
    public class GradesService : IGradesService
    {
        private readonly IGradesRepository gradesRepository;
        public GradesService(IGradesRepository gradesRepository)
        {
            this.gradesRepository = gradesRepository;
        }

        public async Task Delete(int id)
        {
            await gradesRepository.Delete(id);
        }

        public async Task<IActionResult> GenerateRandomData(int lowerBound, int upperBound, int numberOfGradesPerStudent)
        {
            return await gradesRepository.GeneratePrimaryData(lowerBound, upperBound, numberOfGradesPerStudent);
        }

        public async Task<Grade> Get(int id)
        {
            return await gradesRepository.Get(id);
        }
    }
}
