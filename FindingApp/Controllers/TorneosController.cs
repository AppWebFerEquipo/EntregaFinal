using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FindingApp.Application.Services;
using FindingApp.Domain.Entities;
using FindingApp.Domain.Interfaces;
using FindingApp.Domain.Dtos.Responses;
using FindingApp.Domain.Dtos.Requests;
using AutoMapper;
using FluentValidation;
using Microsoft.Extensions.Options;
using FluentValidation.Results;

namespace Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TorneosController : ControllerBase
    {
        private readonly IHttpContextAccessor _httpContext;
        private readonly ITorneosRepository _repository;
        private readonly IMapper _mapper;
        private readonly IValidator<TorneosCreateRequest> _createValidator;

        public TorneosController(IHttpContextAccessor httpContext, ITorneosRepository repository, IMapper mapper, IValidator<TorneosCreateRequest> createValidator)
        {
            this._httpContext = httpContext;
            _repository = repository;
            this._mapper = mapper;
            this._createValidator = createValidator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAll()
        {
            var torneos = await _repository.GetAll();
            var respuesta = _mapper.Map<IEnumerable<TblTournament>,IEnumerable<TorneosResponse>>(torneos);
            return Ok(respuesta);
        } 

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetById(int Id)
        {
            var torneos = await _repository.GetById(Id);

            if(torneos == null)
                return NotFound($"No fue posible encontrar resultados con el id {Id}...");

            var respuesta = _mapper.Map<TblTournament, TorneosResponse>(torneos);
            return Ok(respuesta);
        }

        [HttpGet]
        [Route("Find")]
        public async Task<IActionResult> GetByFilter(TblTournament torneo)
        {
            var torneos = await _repository.GetByFilter(torneo); 
            var respuesta = _mapper.Map<IEnumerable<TblTournament>,IEnumerable<TorneosResponse>>(torneos);
            return Ok(respuesta);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody]TorneosCreateRequest torneo)
        {
            var validationResult = await _createValidator.ValidateAsync(torneo);

            if(!validationResult.IsValid)
                return UnprocessableEntity(validationResult.Errors.Select(x => $"Error: {x.ErrorMessage}"));

            var entity = _mapper.Map<TorneosCreateRequest, TblTournament>(torneo);
            var id = await _repository.Create(entity);

            if(id <= 0)
                return Conflict("El registro no puede ser realizado, verifica tu información...");

            var urlresult = $"https://{_httpContext.HttpContext.Request.Host.Value}/api/person/{id}";
            return Created(urlresult, id);
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> Update(int id, [FromBody]TblTournament torneo)
        {
            if(id <= 0)
                return NotFound("El registro no fué encontrado, veifica tu información...");

            torneo.Id = id;

            var validate = TorneosService.ValidateUpdate(torneo);
            
            if(!validate)
                return UnprocessableEntity("No es posible realizar la modificación, verifica tu información...");

            var update = await _repository.Update(id, torneo);

            if(!update)
                return Conflict("Ocurrió un fallo al intentar realizar la modificación...");

            return NoContent();            
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var entity = await _repository.GetById(id);
            //entity.Status = false;

            var rows = _repository.Update(id, entity);

            return NoContent();
        }
    }
}