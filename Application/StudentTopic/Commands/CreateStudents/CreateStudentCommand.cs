using Application.Interfaces;
using CodeCrafts.Domain.Entities;
using MediatR;

namespace Application.StudentTopic.Commands.CreateStudents;

public class CreateStudentCommand : IRequest<Student>
{
    public string Name { get; init; }
}

public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommand, Student>
{
    private readonly IDemoDbContext _dbContext;
    public CreateStudentCommandHandler(IDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    public async Task<Student> Handle(CreateStudentCommand request, CancellationToken cancellationToken)
    {
        try
        {

            var student = new Student()
            {
                Name = request.Name
            };

            _dbContext.Students.Add(student);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return student;
        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
