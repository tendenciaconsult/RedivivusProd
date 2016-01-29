﻿using Simir.Domain.Entities;

namespace Simir.Domain.Interfaces.Repository
{
    public interface IEquipamentoColetaEventualRepository :
        IRepositoryBase<TBEquipamentoColetaEventual, TBEquipamentoColetaEventualHistorico>
    {
    }
}