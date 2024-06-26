using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AlunosBase.Domain.Model
{
    [Table("turmaa")]
    public class TurmaA
    {
        [Key]

        public int id { get; set; }
        public string nometurma { get; set; }
        public string nome { get; set; }
        public decimal matematica { get; set; }
        public decimal geografia { get; set; }
        public decimal portugues { get; set; }
        public decimal ingles { get; set; }
        public decimal historia { get; set; }
        public decimal ciencias { get; set; }
        public decimal educacaofisica { get; set; }

        [NotMapped]
        public decimal mediatotal
        {
            get
            {
                decimal total = matematica + geografia + portugues + ingles + historia + ciencias + educacaofisica;
                decimal media = total / 7;
                return Math.Round(media, 2, MidpointRounding.AwayFromZero);
            }

        }
        [NotMapped]
        public string aprovado
        {
            get
            {
                if (mediatotal < 6)
                {
                    string reprovado = "Aluno foi reprovado";
                    return reprovado;
                }
                else
                {
                    string alunoAprovado = "Aluno foi aprovado";
                    return alunoAprovado;
                }
            }
        }
    }

        [Table("turmab")]
        public class TurmaB
        {
            [Key]
            public int id { get; set; }
            public string nome { get; set; }
            public decimal matematica { get; set; }
            public decimal geografia { get; set; }
            public decimal portugues { get; set; }
            public decimal ingles { get; set; }
            public decimal historia { get; set; }
            public decimal ciencias { get; set; }
            public decimal educacaofisica { get; set; }
            public decimal mediatotal { get; set; }
        }

        [Table("turmac")]
        public class TurmaC
        {
            [Key]
            public int id { get; set; }
            public string nome { get; set; }
            public decimal matematica { get; set; }
            public decimal geografia { get; set; }
            public decimal portugues { get; set; }
            public decimal ingles { get; set; }
            public decimal historia { get; set; }
            public decimal ciencias { get; set; }
            public decimal educacaofisica { get; set; }
            public decimal mediatotal { get; set; }
        }
    }
