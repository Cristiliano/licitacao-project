﻿using Licitacao.Domain.Entities;
using Licitacao.Domain.Interfaces;
using Licitacao.Infraestructure.Context;

namespace Licitacao.Infraestructure.Repositories
{
    public class PrecoPublicoRepository(LicitacaoContext context) : Repository<PrecoPublicoEntity>(context), IPrecoPublicoRepository
    {
    }
}
