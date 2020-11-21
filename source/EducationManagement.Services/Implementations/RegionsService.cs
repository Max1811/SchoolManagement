using EducationManagement.Services.Interfaces;
using EducatoinManagement.DataAccessLayer.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducationManagement.Services.Implementations
{
    public class RegionsService : IRegionsService
    {
        private readonly IRegionsRepository regionsRepository;
        public RegionsService(IRegionsRepository regionsRepository)
        {
            this.regionsRepository = regionsRepository;
        }
        public async Task<IActionResult> GenerateRandomData(int numberOfRegions, CancellationToken cancellationToken = default)
        {
            return await regionsRepository.GeneratePrimaryData(numberOfRegions, cancellationToken);
        }
    }
}
