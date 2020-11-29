using Dapper;
using EducatoinManagement.DataAccessLayer.Contracts;
using EducatoinManagement.DataAccessLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Implementations
{
    public class RegionsRepository : GenericCrudRepository<Region>, IRegionsRepository
    {
        private readonly IConfiguration _configuration;
        private readonly IBaseDataGeneringRepository baseDataGeneringRepository;
        public RegionsRepository(IConfiguration configuration)
            :base(configuration)
        {
            _configuration = configuration;
            baseDataGeneringRepository = new BaseDataGeneratingRepository(configuration);
        }

        public async Task Delete(int id)
        {
            await Delete(id, "Regions");
        }

        public async Task<IActionResult> GeneratePrimaryData(int numberOfRegions, CancellationToken cancellationToken = default)
        {
            var procedure = "[GenerateRandomRegions]";
            var values = new { RegionsCount = numberOfRegions };

            return await baseDataGeneringRepository.GenerateDataAsync(procedure, "[RegionsSelectAll]", values);
        }

        public async Task<Region> Get(int id)
        {
            return await Get(id, "Regions");
        }
    }
}
