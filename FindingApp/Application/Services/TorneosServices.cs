using System;
using FindingApp.Domain.Entities;

namespace FindingApp.Application.Services
{
    public class TorneosService
    {
        public static bool ValidateUpdate(TblTournament torneo)
        {
            if(torneo.Id <= 0)
                return false;
            
            if(string.IsNullOrEmpty(torneo.Disciplina))
                return false;

            return true;
        }
    }
}