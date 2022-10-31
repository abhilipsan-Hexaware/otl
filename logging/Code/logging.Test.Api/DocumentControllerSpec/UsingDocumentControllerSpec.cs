using NSubstitute;
using logging.Test.Framework;
using logging.Api.Controllers;
using logging.Business.Interfaces;


namespace logging.Test.Api.DocumentControllerSpec
{
    public abstract class UsingDocumentControllerSpec : SpecFor<DocumentController>
    {
        protected IDocumentService _documentService;

        public override void Context()
        {
            _documentService = Substitute.For<IDocumentService>();
            subject = new DocumentController(_documentService);

        }

    }
}
