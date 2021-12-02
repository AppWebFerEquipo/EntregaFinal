using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using FindingApp.Domain.Entities;

namespace FindingApp.Domain.Interfaces
{
    public interface ITorneosRepository
    {
        Task<TblTournament> GetById(int id);
        Task<IQueryable<TblTournament>> GetAll();
        Task<IQueryable<TblTournament>> GetByFilter(TblTournament torneos);
        bool Exist(Expression<Func<TblTournament, bool>> expression);
        Task<int> Create(TblTournament torneos);
        Task<bool> Update(int Id, TblTournament torneos);
    }
}