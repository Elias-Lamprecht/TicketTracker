using NUnit.Framework;
using TicketTracker.CoreLibrary.Models;
using TicketTracker.CoreLibrary.Services;

[TestFixture]
public class PriorityServiceTests
{
    private PriorityService _service;

    [SetUp]
    public void Setup()
    {
        _service = PriorityService.Instance();
    }

    [TearDown]
    public void Teardown()
    {
        _service.DeleteAllPrioritys();
    }

    [TestCase("Title", "")]
    [TestCase("Title", null)]
    [TestCase("", "Description")]
    [TestCase(null, "Description")]
    [TestCase(null, null)]
    public void CreatePriority_ShouldNotCreate_ThrowException(string? title, string? description)
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act & Arrange
        Assert.Throws<ArgumentException>(() => _service.CreatePriority(id, title!, description!));
    }

    [Test]
    public void Instance_ShouldReturnSameObject_WhenCalledTwice()
    {
        // Act
        PriorityService instance1 = PriorityService.Instance();
        PriorityService instance2 = PriorityService.Instance();

        // Assert
        Assert.That(instance1, Is.SameAs(instance2), "PriorityService should be a Singleton.");
    }

    [Test]
    public void CreatePriority_ShouldAddPriorityToList_AndReturnCorrectObject()
    {
        // Arrange
        var id = Guid.NewGuid();
        var title = "Critical";
        var description = "Fix immediately";

        // Act
        Priority result = _service.CreatePriority(id, title, description);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Title, Is.EqualTo(title));
            Assert.That(result.Description, Is.EqualTo(description));
        });
    }

    [Test]
    public void DeletePriority_ShouldRemovePriorityFromList()
    {
        // Arrange
        Priority priority = _service.CreatePriority(Guid.NewGuid(), "Low", "Minor UI bug");

        // Act
        _service.DeletePriority(priority);

        // Assert
        Assert.That(_service.Priorities, Does.Not.Contain(priority));
    }

    [Test]
    public void DeleteAllPriorities_ShouldLeaveListEmpty()
    {
        // Arrange
        _service.CreatePriority(Guid.NewGuid(), "High", "Urgent issue");
        _service.CreatePriority(Guid.NewGuid(), "Low", "Minor tweak");

        // Act
        _service.DeleteAllPrioritys();

        // Assert
        Assert.That(_service.Priorities, Is.Empty);
    }
}