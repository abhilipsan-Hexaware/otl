using System.Collections.Generic;
using logging.BusinessServices.Interfaces;
using logging.BusinessEntities.Entities;
using logging.Contracts.DTO;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace logging.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        IDocumentService _DocumentService;
        private readonly IMapper _mapper;
        public DocumentController(IDocumentService DocumentService,IMapper mapper)
        {
            _DocumentService = DocumentService;
            _mapper = mapper;
        }

        // GET: api/Document
        [HttpGet]
        public ActionResult<IEnumerable<Document>> Get()
        {
            var DocumentDTOs = _mapper.Map<IEnumerable<DocumentDto>>(_DocumentService.GetAll());
            return Ok(DocumentDTOs);
        }

        [HttpGet("{id}")]
        public ActionResult<Document> GetById(string id)
        {
            var DocumentDTO = _mapper.Map<DocumentDto>(_DocumentService.Get(id));
            return Ok(DocumentDTO);
        }

        [HttpPost]
        public ActionResult<Document> Save(Document Document)
        {
            var DocumentDTOs = _mapper.Map<DocumentDto>(_DocumentService.Save(Document));
            return Ok(DocumentDTOs);
        }

        [HttpPut("{id}")]
        public ActionResult<Document> Update([FromRoute] string id, Document Document)
        {
            var DocumentDTOs = _mapper.Map<DocumentDto>(_DocumentService.Update(id, Document));
            return Ok(DocumentDTOs);
        }

        [HttpDelete("{id}")]
        public ActionResult<bool> Delete([FromRoute] string id)
        {
            bool res = _mapper.Map<bool>(_DocumentService.Delete(id));
            if(res== false) return null;
            return Ok(res);

        }


    }
}
