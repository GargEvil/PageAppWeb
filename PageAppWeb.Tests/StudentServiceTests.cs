using Moq;
using PageApp.Infrastracture.Abstractions;
using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.CustomMapper;
using PageAppWeb.DTOs;
using PageAppWeb.Exceptions;
using PageAppWeb.Services;

namespace PageAppWeb.Tests;
public class StudentServiceTests
{
    private readonly Mock<IStudentRepository> _studentRepositoryMock = new();
    private readonly Mock<ICourseRepository> _courseRepositoryMock = new();
    private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
    private readonly StudentService _studentService;


    public StudentServiceTests()
    {
        _studentService = new StudentService(_studentRepositoryMock.Object,
            _courseRepositoryMock.Object,
            _unitOfWorkMock.Object);
    }

    [Fact]
    public async Task AddStudent_EnsureRepositoryCalledOnceAsync()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Add(It.IsAny<Student>())).Verifiable();

        //Act
        await _studentService.AddStudent(Mock.Of<StudentDTO>());

        //Assert
        _studentRepositoryMock.Verify(x => x.Add(It.IsAny<Student>()), Times.Once);

    }

    [Fact]
    public async Task DeleteStudent_ShouldReturnStudentFromDb_EnsureDeleteCalledOnce()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).Returns(Mock.Of<Student>());
        _studentRepositoryMock.Setup(e => e.Remove(It.IsAny<Student>())).Verifiable();

        //Act
        await _studentService.DeleteStudent(It.IsAny<int>());

        //Assert
        _studentRepositoryMock.Verify(x => x.Remove(It.IsAny<Student>()), Times.Once);
    }

    [Fact]
    public async Task DeleteStudent_ShouldThrowException_EnsureDeleteIsNotCalled()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).Returns(() => null);
        _studentRepositoryMock.Setup(e => e.Remove(It.IsAny<Student>())).Verifiable();
        var id = 3333;

        //Act
        var result = await Assert.ThrowsAsync<StudentNotFoundException>(async () =>
                     await _studentService.DeleteStudent(id));


        //Assert
        Assert.Equal("Student with given id 3333 is not found!", result.Message);
        _studentRepositoryMock.Verify(x => x.Remove(It.IsAny<Student>()), Times.Never);
    }

    [Fact]
    public async Task UpdateStudent_ShouldReturnStudentFromDb_EnsureUnitOfWorkCalledOnce()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).Returns(Mock.Of<Student>());
        _unitOfWorkMock.Setup(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()));

        //Act
        await _studentService.UpdateStudent(It.IsAny<int>(), Mock.Of<StudentDTO>());

        //Assert
        _unitOfWorkMock.Verify(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Once);
    }

    [Fact]
    public async Task UpdateStudent_ShouldThrowException_EnsureUnitOfWorkIsNeverCalled()
    {
        //Arrange
        _studentRepositoryMock.Setup(e => e.Get(It.IsAny<int>())).Returns(() => null);
        _unitOfWorkMock.Setup(e => e.SaveChangesAsync(It.IsAny<CancellationToken>()));
        var id = 4421;

        //Act
        var result = await Assert.ThrowsAsync<StudentNotFoundException>(async () =>
                     await _studentService.UpdateStudent(id, It.IsAny<StudentDTO>()));

        //Assert
        Assert.Equal("Student with given id 4421 is not found!", result.Message);
        _unitOfWorkMock.Verify(x => x.SaveChangesAsync(It.IsAny<CancellationToken>()), Times.Never);
    }
}
