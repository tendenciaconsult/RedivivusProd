using System;

namespace Simir.Domain.Enuns
{
    [FlagsAttribute] // explicação: https://msdn.microsoft.com/en-US/LIBRARY/system.flagsattribute
    public enum TipoPermissao
    {
        Consultar = 1,
        Alterar = 2,
        Incluir = 4,
        Excluir = 8,
        Print = 16
    }
}