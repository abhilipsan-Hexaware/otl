using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using logging.Entities.Entities;


namespace logging.Test.Business.DocumentServiceSpec
{
    public class When_updating_document : UsingDocumentServiceSpec
    {
        private Document _result;
        private Document _document;

        public override void Context()
        {
            base.Context();

            _document = new Document
            {
                Name = "Name",
                Address = "Address"
            };

            _documentRepository.Update(_document.Id, _document).Returns(_document);
            
        }
        public override void Because()
        {
            _result = subject.Update(_document.Id, _document);
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _documentRepository.Received(1).Update(_document.Id, _document);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<Document>();

            _result.ShouldBe(_document);
        }
    }
}
