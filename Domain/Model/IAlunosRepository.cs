using AlunosBase.Domain.Model;
using System.Collections.Generic;

namespace AlunosBase.Domain.Model
{
    public interface IAlunosRepository
    {
        void AddTurmaA(TurmaA turmaA);
        List<TurmaA> GetTurmaA();
        void UpdateTurmaA(TurmaA turmaA);
        void DeleteTurmaA(int id);

        void AddTurmaB(TurmaB turmaB);
        List<TurmaB> GetTurmaB();

        void AddTurmaC(TurmaC turmaC);
        List<TurmaC> GetTurmaC();
    }
}
