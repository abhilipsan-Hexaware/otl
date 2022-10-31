using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using validator.Entities.Entities;

namespace validator.Test.Business.DocumentServiceSpec
{
    public class When_getting_all_document : UsingDocumentServiceSpec
    {
        private IEnumerable<Document> _result;

        private IEnumerable<Document> _all_document;
        private Document _document;

        public override void Context()
        {
            base.Context();

            _document = new Document{
                Name = "Name",
                Address = "Address"
            };

            _all_document = new List<Document> { _document};
            _documentRepository.GetAll().Returns(_all_document);
        }
        public override void Because()
        {
            _result = subject.GetAll();
        }

        [Test]
        public void Request_is_routed_through_repository()
        {
            _documentRepository.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.ShouldBeOfType<List<Document>>();

            List<Document> resultList = _result as List<Document>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_document);
        }
    }
}
