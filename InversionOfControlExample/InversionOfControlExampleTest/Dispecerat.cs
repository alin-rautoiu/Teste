using InversionOfControlExample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InversionOfControlExampleTest
{
    [TestClass]
    public class Dispecerat
    {
        [TestMethod]
        public void GivenADispeceratWhenCallAddPersonThenTheMethodAddFromISursaDeDateIsCalled()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = "NumeMock",
                Prenume = "PrenumeMock",
                Varsta = 22
            });

            //act
            A.Add();

            //assert
            sursaDeDateMock.Verify(v => v.Add(It.IsAny<Persoana>()), Times.Exactly(1));
            personInitMock.Verify(v => v.CreatePerson(), Times.Exactly(1));
        }

        [TestMethod]
        public void GivenADispeceratWhenCallAddPersonTwiceThenTheMethodReadByNameIsCalledOnlyOnce()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //setare pe mock

            String Nume = "NumeMock";
            String Prenume = "PrenumeMock";
            int Varsta = 22;

            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = Nume,
                Prenume = Prenume,
                Varsta = Varsta
            });

            //act
            A.ReadByNume(Nume);
         
            //assert
            sursaDeDateMock.Verify(v => v.ReadByName(Nume), Times.Exactly(1));
        }

        [TestMethod]
        public void GivenADispeceratWhenCallAddPersonTwiceThenTheMethodReadAllIsCalledOnlyOnce()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //setare pe mock

            String Nume = "NumeMock";
            String Prenume = "PrenumeMock";
            int Varsta = 22;

            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = Nume,
                Prenume = Prenume,
                Varsta = Varsta
            });

            //act
            A.ReadAll();

            //assert
            sursaDeDateMock.Verify(v => v.ReadAll(), Times.Exactly(1));
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void GivenADispeceratWhenCallAddPersonAndPersonHasVarstaLessThan18ThenAnExceptionIsThrown()
        {
            //arange
            var sursaDeDateMock = new Mock<ISursaDeDate>();
            var personInitMock = new Mock<IPersonInitialization>();

            //setare pe mock
            personInitMock.Setup(s => s.CreatePerson()).Returns(new Persoana()
            {
                Nume = "NumeMock",
                Prenume = "PrenumeMock",
                Varsta = 17
            });

            DispecerA A = new DispecerA(sursaDeDateMock.Object, personInitMock.Object);

            //act
            A.Add();
        }
    }
}
