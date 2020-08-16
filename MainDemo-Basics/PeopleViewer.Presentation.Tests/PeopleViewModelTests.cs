using Common;
using NUnit.Framework;
using System.Linq;

namespace PeopleViewer.Presentation.Tests
{
    public class PeopleViewModelTests
    {
        private IPersonReader GetTestReader()
        {
            return new FakeReader();
        }

        [Test]
        public void RefreshPeople_OnExecute_PeopleIsPopulated()
        {
            // Arrange
            var reader = GetTestReader();
            var vm = new PeopleViewModel(reader);

            // Act
            vm.RefreshPeople();

            // Assert
            Assert.IsNotNull(vm.People);
            Assert.AreEqual(2, vm.People.Count());
        }

        [Test]
        public void ClearPeople_OnExecute_PeopleIsEmpty()
        {
            // Arrange
            var reader = GetTestReader();
            var vm = new PeopleViewModel(reader);
            vm.RefreshPeople();
            Assert.AreEqual(2, vm.People.Count(), "Invalid Arrangement");

            // Act
            vm.ClearPeople();

            // Assert
            Assert.AreEqual(0, vm.People.Count());
        }
    }
}