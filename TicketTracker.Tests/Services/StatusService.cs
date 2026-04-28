using NUnit.Framework;
using TicketTracker.CoreLibrary.Models;
using TicketTracker.CoreLibrary.Services;

namespace TicketTracker.Tests.Services;

[TestFixture]
public class StatusServiceTests
{
    [SetUp]
    public void Setup()
    {
        _statusService = new StatusService();
    }

    [TearDown]
    public void TearDown()
    {
        _statusService.DeleteAllStatuses();
    }

    private StatusService _statusService;

    [TestCase("Title", "")]
    [TestCase("Title", null)]
    [TestCase("", "Description")]
    [TestCase(null, "Description")]
    [TestCase(null, null)]
    public void CreateStatus_ShouldNotCreate_ThrowException(string? title, string? description)
    {
        // Arrange
        Guid id = Guid.NewGuid();

        // Act & Arrange
        Assert.Throws<ArgumentException>(() => _statusService.CreateStatus(id, title!, description!));
    }

    [Test]
    public void Instance_ShouldReturnSameObject_WhenCalledTwice()
    {
        // Act
        StatusService instance1 = StatusService.Instance();
        StatusService instance2 = StatusService.Instance();

        // Assert
        Assert.That(instance1, Is.SameAs(instance2), "StatusService should be a Singleton.");
    }

    [Test]
    public void CreateStatus_ShouldAddStatusToList_AndReturnCorrectObject()
    {
        // Arrange
        Guid id = Guid.NewGuid();
        string title = "Critical";
        string description = "Fix immediately";

        // Act
        Status result = _statusService.CreateStatus(id, title, description);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Title, Is.EqualTo(title));
            Assert.That(result.Description, Is.EqualTo(description));
        });
    }

    [Test]
    public void DeleteStatus_ShouldRemoveStatusFromList()
    {
        // Arrange
        Status status = _statusService.CreateStatus(Guid.NewGuid(), "Low", "Minor UI bug");

        // Act
        _statusService.DeleteStatus(status);

        // Assert
        Assert.That(_statusService.Statuses, Does.Not.Contain(status));
    }

    [Test]
    public void DeleteAllStatuses_ShouldLeaveListEmpty()
    {
        // Arrange
        _statusService.CreateStatus(Guid.NewGuid(), "High", "Urgent issue");
        _statusService.CreateStatus(Guid.NewGuid(), "Low", "Minor tweak");

        // Act
        _statusService.DeleteAllStatuses();

        // Assert
        Assert.That(_statusService.Statuses, Is.Empty);
    }
}