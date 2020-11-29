using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface ISchoolsService
    {
        public Task<IActionResult> GenerateRandomData(int lowerBoundPerRegion, int UpperBoundPerRegion);

        public Task<School> Get(int id);

        Task Delete(int id);
    }
}
