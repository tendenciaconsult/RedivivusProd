﻿using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class ColetaExecutadaDetalhadaRepository :
        RepositoryBase<TBColetaExecutadaDetalhada, TBColetaExecutadaDetalhadaHistorico>,
        IColetaExecutadaDetalhadaRepository
    {
    }
}