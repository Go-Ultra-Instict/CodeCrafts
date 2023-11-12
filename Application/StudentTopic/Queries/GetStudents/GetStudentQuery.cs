using Application.Interfaces;
using AutoMapper;
using CodeCrafts.Domain.Entities;
using CodeCrafts.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;


namespace Application.StudentTopic.Queries.GetStudents;

public class GetStudentQuery : IRequest<StudentDto>
{
    public int Id { get; set; }
}

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
{
    private readonly IMapper _mapper;
    public GetStudentQueryHandler(IDemoDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public IDemoDbContext _dbContext { get; }

    public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {

        Student? student = await _dbContext.Students.Where(x => x.Id == request.Id).FirstOrDefaultAsync(cancellationToken);

        if (student == null)
        {
            throw new NotFoundCustomException("Item not found");
        }

        StudentDto? dest = _mapper.Map<Student, StudentDto>(student);

        //Test auto mapper
        Student? backtoStudent= _mapper.Map<StudentDto,Student>(dest);
        List<StudentDto>? destList1 = _mapper.Map<List<Student>, List<StudentDto>>( new List<Student> { student});
        List<Student>? destList2 = _mapper.Map<List<StudentDto>, List<Student>>(new List<StudentDto> { dest });

        return dest;
    }
}

/***
 * old code
 *   //throw new NotFoundCustomException(nameof(Student),"doest has this id");
        //throw new NotImplementedException("TEST");

        //var student = await _dbContext.Students.Where(x => x.Id == request.Id).Select(x => new StudentDto
        //{
        //    Id = x.Id,
        //    Name2 = x.Name,
        //}).FirstOrDefaultAsync(cancellationToken);
 */