﻿using Simir.Domain.Entities;
using Simir.Domain.Interfaces.Repository;

namespace Simir.Infra.Data.Repositories
{
    public class EquipamentoLimpezaEventualRepository :
        RepositoryBase<TBEquipamentoLimpezaEventual, TBEquipamentoLimpezaEventualHistorico>,
        IEquipamentoLimpezaEventualRepository
    {
    }
}