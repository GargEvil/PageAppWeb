using PageApp.Infrastracture.Models;
using PageApp.Infrastracture.Repositories;
using PageAppWeb.Exceptions;

namespace PageAppWeb.Services;

public class StudentService : IStudentService
{
    private readonly IStudentRepository _studentRepository;

    public StudentService(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task AddStudent(Student student)
    {
        await _studentRepository.Add(student);
    }

    public async Task DeleteStudent(int id)
    {
        var student = await _studentRepository.GetById(id);

        if (student == null)
            throw new StudentNotFoundException(id);

        await _studentRepository.Delete(student);
    }

    public async Task<List<Student>> GetAllStudents()
    {
        return await _studentRepository.GetAll();
    }

    public async Task<Student> UpdateStudent(int id, Student student)
    {
        var studentToBeUpdated = await _studentRepository.GetById(id);

        if (studentToBeUpdated == null)
            throw new StudentNotFoundException(id);

        studentToBeUpdated.Name = student.Name;
        studentToBeUpdated.Surname = student.Surname;
        studentToBeUpdated.IndexNumber = student.IndexNumber;
        studentToBeUpdated.StudentStatusId = student.StudentStatusId;
        studentToBeUpdated.Year = student.Year;

        return await _studentRepository.Update(studentToBeUpdated);
    }
}
