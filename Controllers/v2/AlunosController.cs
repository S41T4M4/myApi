using Microsoft.AspNetCore.Mvc;
using AlunosBase.Domain.Model;
using AlunosBase.Application.ViewModel;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using System.Text;
using System;

namespace Alunos.Controllers
{
    [ApiController]
    [Route("api/v{version:apiVersion}/alunos")]
    [ApiVersion("2.0")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosRepository _alunosRepository;

        public AlunosController(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        [HttpPost("add-turma-a")]
        public IActionResult AddTurmaA([FromBody] TurmaAViewModel turmaAViewModel)
        {
            try
            {
                var turmaA = new TurmaA
                {
                    nometurma = turmaAViewModel.NomeTurma,
                    id = turmaAViewModel.Id,
                    nome = turmaAViewModel.Nome,
                    matematica = turmaAViewModel.Matematica,
                    geografia = turmaAViewModel.Geografia,
                    portugues = turmaAViewModel.Portugues,
                    ingles = turmaAViewModel.Ingles,
                    historia = turmaAViewModel.Historia,
                    ciencias = turmaAViewModel.Ciencias,
                    educacaofisica = turmaAViewModel.EducacaoFisica,

                };

                _alunosRepository.AddTurmaA(turmaA);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao adicionar : {ex.Message}");
            }
        }

        [HttpGet("get-turma-a")]
        public IActionResult GetTurmaA()
        {
            try
            {
                var turmaAList = _alunosRepository.GetTurmaA();
                var viewModelList = new List<TurmaAViewModel>();
                foreach (var turmaA in turmaAList)
                {
                    var viewModel = new TurmaAViewModel
                    {
                        Id = turmaA.id,
                        Nome = turmaA.nome,
                        NomeTurma = turmaA.nometurma,
                        Matematica = turmaA.matematica,
                        Geografia = turmaA.geografia,
                        Portugues = turmaA.portugues,
                        Ingles = turmaA.ingles,
                        Historia = turmaA.historia,
                        Ciencias = turmaA.ciencias,
                        EducacaoFisica = turmaA.educacaofisica
                 
                    };

                    viewModelList.Add(viewModel);
                }

                return Ok(viewModelList);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao obter turmas: {ex.Message}");
            }
        }

        [HttpDelete("delete-turma-a/{id}")]
        public IActionResult DeleteTurmaA(int id)
        {
            try
            {
                _alunosRepository.DeleteTurmaA(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao deletar turma: {ex.Message}");
            }
        }

        [HttpPut("edit-turma-a/{id}")]
        public IActionResult EditTurmaA(int id, [FromBody] TurmaAViewModel turmaAViewModel)
        {
            try
            {
                var turmaA = new TurmaA
                {
                    nometurma=turmaAViewModel.NomeTurma,
                    id = id,
                    nome = turmaAViewModel.Nome,
                    matematica = turmaAViewModel.Matematica,
                    geografia = turmaAViewModel.Geografia,
                    portugues = turmaAViewModel.Portugues,
                    ingles = turmaAViewModel.Ingles,
                    historia = turmaAViewModel.Historia,
                    ciencias = turmaAViewModel.Ciencias,
                    educacaofisica = turmaAViewModel.EducacaoFisica,
               
                };

                _alunosRepository.UpdateTurmaA(turmaA);

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao editar turma: {ex.Message}");
            }
        }

        [HttpGet("download-turma-a-csv")]
        public IActionResult DownloadTurmaACSV()
        {
            try
            {
                var turmaAList = _alunosRepository.GetTurmaA();
                var memoryStream = new MemoryStream();

                using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
                {
                    using (var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.InvariantCulture)))
                    {
                        csvWriter.WriteRecords(turmaAList);
                    }
                }

                memoryStream.Seek(0, SeekOrigin.Begin);

                return File(memoryStream, "text/csv", "Download_Turma_A.csv");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Erro ao gerar CSV: {ex.Message}");
            }
        }
    }
}
