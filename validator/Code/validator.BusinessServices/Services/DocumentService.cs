using validator.BusinessServices.Interfaces;
using validator.Data.Interfaces;
using validator.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace validator.BusinessServices.Services
{
    public class DocumentService : IDocumentService
    {
        IDocumentRepository _DocumentRepository;

        public DocumentService(IDocumentRepository DocumentRepository)
        {
           this._DocumentRepository = DocumentRepository;
        }
        public IEnumerable<Document> GetAll()
        {
            return _DocumentRepository.GetAll();
        }

        public Document Get(string id)
        {
            return _DocumentRepository.Get(id);
        }

        public Document Save(Document Document)
        {
            _DocumentRepository.Save(Document);
            return Document;
        }

        public Document Update(string id, Document Document)
        {
            return _DocumentRepository.Update(id, Document);
        }

        public bool Delete(string id)
        {
            return _DocumentRepository.Delete(id);
        }

    }
}
