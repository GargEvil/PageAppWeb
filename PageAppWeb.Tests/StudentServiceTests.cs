using Moq;
using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.Exceptions;
using PageAppWeb.Services;

namespace PageAppWeb.Tests;
public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock = new();
    private readonly StudentService _studentService;


    public StudentServiceTests()
    {
        _studentService = new StudentService(_studentRepositoryMock.Object);
    }

    [Fact]
    public async Task AddStudent_EnsureRepositoryCalledOnceAsync()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Add(It.IsAny<Student>())).Verifiable();

        //Act
        await _studentService.AddStudent(It.IsAny<Student>());

        //Assert
        _studentRepositoryMock.Verify(x => x.Add(It.IsAny<Student>()), Times.Once);

    }

    [Fact]
    public async Task DeleteStudent_ShouldReturnStudentFromDb_EnsureDeleteCalledOnce()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(Mock.Of<Student>());
        _studentRepositoryMock.Setup(e => e.Delete(It.IsAny<Student>())).Verifiable();

        //Act
        await _studentService.DeleteStudent(It.IsAny<int>());

        //Assert
        _studentRepositoryMock.Verify(x => x.Delete(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public async Task DeleteStudent_ShouldThrowException_EnsureDeleteIsNotCalled()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
        _studentRepositoryMock.Setup(e => e.Delete(It.IsAny<Student>())).Verifiable();
        var id = 3333;

        //Act
        var result = await Assert.ThrowsAsync<StudentNotFoundException>(async () =>
                     await _studentService.DeleteStudent(id));


        //Assert
        Assert.Equal("Student with given id 3333 is not found!", result.Message);
        _studentRepositoryMock.Verify(x => x.Delete(It.IsAny<Student>()), Times.Never);
    }

    [Fact]
    public async Task UpdateStudent_ShouldReturnStudentFromDb_EnsureUpdateCalledOnce()
    {
        //Arrange
        var student = new Student
        {
            Name = "John",
            Surname = "Doe",
            Year = 3,
            IndexNumber = "IB4343",
            StudentStatusId = 1
        };
        var newStudent = new Student
        {
            Name = "John",
            Surname = "Johnson",
            Year = 1,
            IndexNumber = "IB4343",
            StudentStatusId = 1
        };
        _studentRepositoryMock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(student);
        _studentRepositoryMock.Setup(e => e.Update(It.IsAny<Student>())).ReturnsAsync(student);

        //Act
        var result = await _studentService.UpdateStudent(It.IsAny<int>(), newStudent);

        //Assert
        Assert.Equal(result.Surname, newStudent.Surname);
        Assert.Equal(result.Year, newStudent.Year);
        _studentRepositoryMock.Verify(e => e.Update(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public async Task UpdateStudent_ShouldThrowException_EnsureUpdateIsNeverCalled()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.GetById(It.IsAny<int>())).ReturnsAsync(() => null);
        _studentRepositoryMock.Setup(e => e.Update(It.IsAny<Student>())).Verifiable();
        var id = 4421;

        //Act
        var result = await Assert.ThrowsAsync<StudentNotFoundException>(async () =>
                     await _studentService.UpdateStudent(id, It.IsAny<Student>()));

        //Assert
        Assert.Equal("Student with given id 4421 is not found!", result.Message);
        _studentRepositoryMock.Verify(x => x.Update(It.IsAny<Student>()), Times.Never);
    }
}
