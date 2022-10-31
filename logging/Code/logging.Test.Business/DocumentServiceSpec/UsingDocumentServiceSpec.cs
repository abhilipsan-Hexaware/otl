using NSubstitute;
using logging.Test.Framework;
using logging.Business.Services;
using logging.Data.Interfaces;

namespace logging.Test.Business.DocumentServiceSpec
{
    public abstract class UsingDocumentServiceSpec : SpecFor<DocumentService>
    {
        protected IDocumentRepository _documentRepository;

        public override void Context()
        {
            _documentRepository = Substitute.For<IDocumentRepository>();
            subject = new DocumentService(_documentRepository);

        }

    }
}
