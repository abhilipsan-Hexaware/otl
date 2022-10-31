using logging.BusinessEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace logging.Data.Interfaces
{
    public interface IDocumentRepository : IGetAll<Document>,IGet<Document,string>, ISave<Document>, IUpdate<Document, string>, IDelete<string>
    {
    }
}
