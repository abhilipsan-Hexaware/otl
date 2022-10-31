using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using logging.Entities.Entities;

namespace logging.Test.Api.DocumentControllerSpec
{
    public class When_getting_all_document : UsingDocumentControllerSpec
    {
        private ActionResult<IEnumerable<Document>> _result;

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
            _documentService.GetAll().Returns(_all_document);
        }
        public override void Because()
        {
            _result = subject.Get();
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _documentService.Received(1).GetAll();

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<List<Document>>();

            List<Document> resultList = resultListObject as List<Document>;

            resultList.Count.ShouldBe(1);

            resultList.ShouldBe(_all_document);
        }
    }
}
