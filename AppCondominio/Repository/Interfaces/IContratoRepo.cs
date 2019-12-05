﻿using AppCondominio.Models;
using System.Collections.Generic;

namespace AppCondominio.Repository.Interfaces
{
    public interface IContratoRepo
    {
        IList<Contrato> GetContratos();
        IList<Contrato> GetContratos(Locador locador);
        IList<Contrato> GetContratos(Locatario locatario);
        Contrato CreateContrato(Contrato contrato);//Deve estar preenchido com locador e locatario
    }
}
