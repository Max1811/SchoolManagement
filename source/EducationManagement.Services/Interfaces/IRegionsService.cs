using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationManagement.Services.Interfaces
{
    public interface IRegionsService
    {
        public Task<IActionResult> GenerateRandomData(int numberOfRegions, CancellationToken cancellationToken = default);

        public Task<Region> Get(int id);

        Task Delete(int id);

    }
}
