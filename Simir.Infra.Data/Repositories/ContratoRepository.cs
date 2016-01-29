﻿using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simir.Infra.Data.Repositories
{
    public class ContratoRepository : RepositoryBase<TBContrato, TBContratoHistorico>,
        IContratoRepository
    {
    }
}
