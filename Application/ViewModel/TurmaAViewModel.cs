using System;

namespace AlunosBase.Application.ViewModel
{
    public class TurmaAViewModel
    {
        public string NomeTurma {  get; set; }  
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Matematica { get; set; }
        public decimal Geografia { get; set; }
        public decimal Portugues { get; set; }
        public decimal Ingles { get; set; }
        public decimal Historia { get; set; }
        public decimal Ciencias { get; set; }
        public decimal EducacaoFisica { get; set; }
        public decimal MediaTotal
        {
            get
            {
                decimal total = Matematica + Geografia + Portugues + Ingles + Historia + Ciencias + EducacaoFisica;
                decimal media = total / 7;
                return Math.Round(media, 2, MidpointRounding.AwayFromZero);
            }
        }
        public string Aprovado
        {
            get
            {
                if (MediaTotal >= 6)
                {
                    string alunoAprovado = "Aluno foi aprovado ✔️";
                    return alunoAprovado;
                }
                else
                {
                    string alunoReprovado = "Aluno foi reprovado ❌";
                    return alunoReprovado;
                }
            }
        }
    }
}
