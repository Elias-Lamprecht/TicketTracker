using NUnit.Framework;
using TicketTracker.Models;
using TicketTracker.Services;

namespace TicketTracker.Tests.Services;

[TestFixture]
public class NoteServiceTests
{
    private NoteService _noteService;

    [SetUp]
    public void Setup()
    {
        _noteService = NoteService.Instance();
    }

    [TearDown]
    public void Teardown()
    {
        _noteService.DeleteAllNotes();
    }

    [TestCase(null)]
    [TestCase("")]
    public void CreateNote_ShouldNotCreate_ThrowException(string? text)
    {
        // Arrange
        Guid id  = Guid.NewGuid();

        // Act & Assert
        Assert.Throws<ArgumentException>(() => _noteService.CreateNote(id, text!));
    }

    [Test]
    public void Instance_ShouldReturnSameObject_WhenCalledTwice()
    {
        // Act
        NoteService instance1 = NoteService.Instance();
        NoteService instance2 = NoteService.Instance();

        // Assert
        Assert.That(instance1, Is.SameAs(instance2));
    }

    [Test]
    public void CreateNote_ShouldAddNoteToList_AndReturnCorrectObject()
    {
        // Arrange
        var id = Guid.NewGuid();
        var text = "customer is great...";

        // Act
        Note result = _noteService.CreateNote(id, text);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(result.Id, Is.EqualTo(id));
            Assert.That(result.Text, Is.EqualTo(text));
        });
    }

    [Test]
    public void DeleteNote_ShouldRemoveNoteFromList()
    {
        // Arrange
        Note note = _noteService.CreateNote(Guid.NewGuid(), "Great Customer!");

        // Act
        _noteService.DeleteNote(note);

        // Assert
        Assert.That(_noteService.Notes, Does.Not.Contain(note));
    }

    [Test]
    public void DeleteAllNotes_ShouldLeaveListEmpty()
    {
        // Arrange
        _noteService.CreateNote(Guid.NewGuid(), "Example1");
        _noteService.CreateNote(Guid.NewGuid(), "Example2");

        // Act
        _noteService.DeleteAllNotes();

        // Assert
        Assert.That(_noteService.Notes, Is.Empty);
    }
}
