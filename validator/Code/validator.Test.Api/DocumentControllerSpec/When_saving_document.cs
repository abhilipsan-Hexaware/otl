using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using NSubstitute;
using Shouldly;
using Microsoft.AspNetCore.Mvc;
using validator.Entities.Entities;

namespace validator.Test.Api.DocumentControllerSpec
{
    public class When_saving_document : UsingDocumentControllerSpec
    {
        private ActionResult<Document> _result;

        private Document _document;

        public override void Context()
        {
            base.Context();

            _document = new Document
            {
                Name = "Name",
                Address = "Address"
            };

            _documentService.Save(_document).Returns(_document);
        }
        public override void Because()
        {
            _result = subject.Save(_document);
        }

        [Test]
        public void Request_is_routed_through_service()
        {
            _documentService.Received(1).Save(_document);

        }

        [Test]
        public void Appropriate_result_is_returned()
        {
            _result.Result.ShouldBeOfType<OkObjectResult>();

            var resultListObject = (_result.Result as OkObjectResult).Value;

            resultListObject.ShouldBeOfType<Document>();

            var resultList = (Document)resultListObject;

            resultList.ShouldBe(_document);
        }
    }
}
