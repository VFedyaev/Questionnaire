using Microsoft.VisualStudio.TestTools.UnitTesting;
using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using System.Web.ModelBinding;
using Questionnaire.BLL.Services;
using Questionnaire.DAL.Repositories;
using Questionnaire.BLL.Interfaces;

namespace Questionnaire.BLL.Tests.Services.Tests
{
    [TestClass]
    public class QuestionTypeService_Tests : BaseInit
    {
        private Mock<UnitOfWork> _mockRepository;
        private ModelStateDictionary _modelState;
        private IQuestionTypeService _service;

        [TestInitialize]
        public void TestInitialize()
        {
            //_mockRepository = new Mock<UnitOfWork>();
            //_modelState = new ModelStateDictionary();
            //_service = new QuestionTypeService(new ModelStateWrapper(_modelState), _mockRepository.Object);
            base.QuestionTypeInitialize();
        }

        //[TestMethod]
        //public void Get_GetElementById_ReturnsGetElementById()
        //{
        //    //Arrange

        //    //Act

        //    //Assert
        //}
        [TestMethod]
        public void Create_TryToAddElementIntoDbWithNotEmptyFileds_ReturnsTrue()
        {
            //Arrange
            var item = new QuestionTypeDTO { Name = $"New-{DateTime.Now}" };
            //Act
            QuestionTypeService.Add(item);
            //Assert
            Assert.IsTrue(moqQuestionTypeRepository.Items.Any(t=>t.Name == item.Name));
        }

        [TestMethod]
        public void Create_TryToAddElementIntoDbWithEmptyFileds_ReturnsRequired()
        {
            //Arrange
            var item = new QuestionTypeDTO { Name = "" };
            //Act
            QuestionTypeService.Add(item);
            //Assert
            Assert.IsTrue(moqQuestionTypeRepository.Items.Any(t => t.Name == item.Name));
            var error = _modelState["Name"].Errors[0];
            Assert.AreEqual("Заполните поле!", error.ErrorMessage);
        }
    }
}
