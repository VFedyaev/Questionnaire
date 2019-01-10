using Microsoft.VisualStudio.TestTools.UnitTesting;
using Questionnaire.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questionnaire.BLL.Tests.Services.Tests
{
    [TestClass]
    public class QuestionTypeService_Tests : BaseInit
    {
        [TestInitialize]
        public void TestInitialize()
        {
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
        public void Create_FiledsNotEmptyAddElementIntoDB_CreateIsOk()
        {
            //Arrange
            var item = new QuestionTypeDTO { Name = $"New-{DateTime.Now}" };
            //Act
            QuestionTypeService.Add(item);
            //Assert
            Assert.IsTrue(moqQuestionTypeRepository.Items.Any(t=>t.Name == item.Name));
        }
    }
}
