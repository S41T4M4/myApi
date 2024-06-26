using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Collections.Generic;
using System.IO;
using CsvHelper;
using CsvHelper.Configuration;
using System.Globalization;
using AlunosBase.Domain.Model;
using AlunosBase.Application.ViewModel;

namespace AlunosBase.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/alunos")]
    [ApiVersion("1.0")]
    public class AlunosController : ControllerBase
    {
        private readonly IAlunosRepository _alunosRepository;

        public AlunosController(IAlunosRepository alunosRepository)
        {
            _alunosRepository = alunosRepository;
        }

        [HttpPost("add-turma-a")]
        public IActionResult AddTurmaA([FromForm] TurmaAViewModel turmaAViewModel)
        {
            var turmaA = new TurmaA
            {
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

        [HttpGet("get-turma-a")]
        public IActionResult GetTurmaA()
        {
            var turmaAList = _alunosRepository.GetTurmaA();
            return Ok(turmaAList);
        }

        [HttpPost("add-turma-b")]
        public IActionResult AddTurmaB([FromForm] TurmaBViewModel turmaBViewModel)
        {
            var turmaB = new TurmaB
            {
                nome = turmaBViewModel.Nome,
                matematica = turmaBViewModel.Matematica,
                geografia = turmaBViewModel.Geografia,
                portugues = turmaBViewModel.Portugues,
                ingles = turmaBViewModel.Ingles,
                historia = turmaBViewModel.Historia,
                ciencias = turmaBViewModel.Ciencias,
                educacaofisica = turmaBViewModel.EducacaoFisica,
                mediatotal = turmaBViewModel.MediaTotal
            };

            _alunosRepository.AddTurmaB(turmaB);

            return Ok();
        }

        [HttpGet("get-turma-b")]
        public IActionResult GetTurmaB()
        {
            var turmaBList = _alunosRepository.GetTurmaB();
            return Ok(turmaBList);
        }

        [HttpPost("add-turma-c")]
        public IActionResult AddTurmaC([FromForm] TurmaCViewModel turmaCViewModel)
        {
            var turmaC = new TurmaC
            {
                nome = turmaCViewModel.Nome,
                matematica = turmaCViewModel.Matematica,
                geografia = turmaCViewModel.Geografia,
                portugues = turmaCViewModel.Portugues,
                ingles = turmaCViewModel.Ingles,
                historia = turmaCViewModel.Historia,
                ciencias = turmaCViewModel.Ciencias,
                educacaofisica = turmaCViewModel.EducacaoFisica,
                mediatotal = turmaCViewModel.MediaTotal
            };

            _alunosRepository.AddTurmaC(turmaC);

            return Ok();
        }

        [HttpGet("get-turma-c")]
        public IActionResult GetTurmaC()
        {
            var turmaCList = _alunosRepository.GetTurmaC();
            return Ok(turmaCList);
        }

        [HttpGet("download-turma-a-csv")]
        public IActionResult DownloadTurmaACSV()
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

            return File(memoryStream, "text/csv", "turmaA.csv");
        }

        [HttpGet("download-turma-b-csv")]
        public IActionResult DownloadTurmaBCSV()
        {
            var turmaBList = _alunosRepository.GetTurmaB();
            var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
            {
                using (var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csvWriter.WriteRecords(turmaBList);
                }
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream, "text/csv", "turmaB.csv");
        }

        [HttpGet("download-turma-c-csv")]
        public IActionResult DownloadTurmaCCSV()
        {
            var turmaCList = _alunosRepository.GetTurmaC();
            var memoryStream = new MemoryStream();

            using (var streamWriter = new StreamWriter(memoryStream, Encoding.UTF8, 1024, true))
            {
                using (var csvWriter = new CsvWriter(streamWriter, new CsvConfiguration(CultureInfo.InvariantCulture)))
                {
                    csvWriter.WriteRecords(turmaCList);
                }
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return File(memoryStream, "text/csv", "turmaC.csv");
        }
    }
}
