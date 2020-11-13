using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface ISchoolRepository
    {
        public Task<IActionResult> GeneratePrimaryData(int lowerBoundPerRegion, int UpperBoundPerRegion);
    }
}
