using System;
using System.Collections.Generic;
using System.Text;
using logging.BusinessEntities.Entities;
using logging.BusinessServices.Interfaces;
using logging.Data.Interfaces;
using RestSharp;

namespace logging.BusinessServices.Services
{
    public class DocumentService : IDocumentService
    {
        IDocumentRepository _DocumentRepository;
        RestClient _client;

        public DocumentService(IDocumentRepository DocumentRepository)
        {
            _client = new RestClient("https://localhost:5003/");
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
            var url = "Document/Validate";
            var request = new RestRequest(url, Method.Post);
            request.RequestFormat = RestSharp.DataFormat.Json;
            request.AddBody(Document);
            var response = _client.Execute(request);
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
