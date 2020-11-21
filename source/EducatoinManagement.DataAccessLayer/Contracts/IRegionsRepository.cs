using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IRegionsRepository
    {
        public Task<IActionResult> GeneratePrimaryData(int numberOfRegions, CancellationToken cancellationToken = default);
    }
}
