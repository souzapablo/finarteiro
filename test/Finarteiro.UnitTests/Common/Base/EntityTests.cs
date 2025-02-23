using Finarteiro.UnitTests.Fakers.Suppliers;
using FluentAssertions;
using System.ComponentModel;

namespace Finarteiro.UnitTests.Common.Base;

public class EntityTests
{
    [Fact, DisplayName("Entities should set IsDelete to true when Delete is called")]
    public void ShouldSetIsDeleteToTrue_WhenDeleteIsCalled()
    {
        // Arrange
        var sut = SupplierFaker.Generate();

        // Act
        sut.Delete();

        // Assert
        sut.IsDeleted.Should().BeTrue();
    }

    [Fact, DisplayName("Entities should update LastUpdate when Delete is called")]
    public void ShouldUpdateLastUpdate_WhenDeleteIsCalled()
    {
        // Arrange
        var sut = SupplierFaker.Generate();
        var initialDate = sut.LastUpdate;

        // Act
        sut.Delete();

        // Assert
        sut.LastUpdate.Should().NotBe(initialDate);
    }
}
