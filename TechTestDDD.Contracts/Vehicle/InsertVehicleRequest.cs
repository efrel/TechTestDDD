﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TechTestDDD.Contracts.Vehicle
{
    public record InsertVehicleRequest(Domain.Entities.Vehicle Vehicle);
}
