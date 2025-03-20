using Finarteiro.UnitTests.Fakers.Suppliers;
using System.ComponentModel;

namespace Finarteiro.UnitTests.Common.Base;

public class EntityTests
{
    [Fact, DisplayName("Entities should set IsDelete to true when deleted")]
    public void ShouldSetIsDeleteToTrue_WhenDeleteIsCalled()
    {
        // Arrange
        var sut = CustomerFaker.Generate();

        // Act
        sut.Delete();

        // Assert
        Assert.True(sut.IsDeleted); 
    }

    [Fact, DisplayName("Entities should update LastUpdate when deleted")]
    public void ShouldUpdateLastUpdate_WhenDeleteIsCalled()
    {
        // Arrange
        var sut = CustomerFaker.Generate();
        var initialDate = sut.LastUpdate;

        // Act
        sut.Delete();

        // Assert
        Assert.True(sut.LastUpdate > initialDate);
    }
}
