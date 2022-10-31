using validator.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace validator.BusinessServices.Interfaces
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
