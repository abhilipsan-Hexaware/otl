using logging.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace logging.BusinessServices.Interfaces
{
    public interface IDocumentService
    {      
        IEnumerable<Document> GetAll();
        Document Get(string id);
        Document Save(Document classification);
        Document Update(string id, Document classification);
        bool Delete(string id);

    }
}
