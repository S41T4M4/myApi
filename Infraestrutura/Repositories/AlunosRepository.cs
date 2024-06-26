using AlunosBase.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AlunosBase.Infraestrutura.Repositories
{
    public class AlunosRepository : IAlunosRepository
    {
        private readonly ConnectionContext _context = new ConnectionContext();

        public void AddTurmaA(TurmaA turmaA)
        {
            _context.TurmaA.Add(turmaA);
            _context.SaveChanges();
        }

        public void AddTurmaB(TurmaB turmaB)
        {
            _context.TurmaB.Add(turmaB);
            _context.SaveChanges();
        }

        public void AddTurmaC(TurmaC turmaC)
        {
            _context.TurmaC.Add(turmaC);
            _context.SaveChanges();
        }



        public List<TurmaA> GetTurmaA()
        {
            return _context.TurmaA.ToList();
        }

        public List<TurmaB> GetTurmaB()
        {
            return _context.TurmaB.ToList();
        }

        public List<TurmaC> GetTurmaC()
        {
            return _context.TurmaC.ToList();
        }
        public void DeleteTurmaA(int id)
        {
            var turmaA = _context.TurmaA.FirstOrDefault(t => t.id == id);
            if (turmaA != null)
            {
                _context.TurmaA.Remove(turmaA);
                _context.SaveChanges();
            }
            else
            {
                throw new Exception($"TurmaA com ID {id} não encontrada.");
            }
        }

        public void UpdateTurmaA(TurmaA turmaA)
        {
            var existingTurmaA = _context.TurmaA.FirstOrDefault(t => t.id == turmaA.id);
            if (existingTurmaA != null)
            {
                existingTurmaA.nometurma = turmaA.nometurma;
                existingTurmaA.nome = turmaA.nome;
                existingTurmaA.matematica = turmaA.matematica;
                existingTurmaA.geografia = turmaA.geografia;
                existingTurmaA.portugues = turmaA.portugues;
                existingTurmaA.ingles = turmaA.ingles;
                existingTurmaA.historia = turmaA.historia;
                existingTurmaA.ciencias = turmaA.ciencias;
                existingTurmaA.educacaofisica = turmaA.educacaofisica;
     

                _context.SaveChanges();
            }
        }
    }
}
