﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EducatoinManagement.DataAccessLayer.Contracts
{
    public interface IClassesRepository
    {
        public Task<IActionResult> GeneratePrimaryData(int maxAmountOfParalelClasses);
    }
}
