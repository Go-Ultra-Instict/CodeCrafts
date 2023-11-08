﻿using Application.Interfaces;
using Application.StudentTopic.Commands.CreateStudents;
using AutoMapper.QueryableExtensions;
using CodeCrafts.Domain.Entities;
using CodeCrafts.Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Net;
using System.Web.Http;

namespace Application.StudentTopic.Queries.GetStudents;

public class GetStudentQuery : IRequest<StudentDto>
{
    public int Id { get; set; }
}

public class GetStudentQueryHandler : IRequestHandler<GetStudentQuery, StudentDto>
{
    public GetStudentQueryHandler(IDemoDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IDemoDbContext _dbContext { get; }

    public async Task<StudentDto> Handle(GetStudentQuery request, CancellationToken cancellationToken)
    {

        //throw new NotFoundCustomException(nameof(Student),"doest has this id");
        //throw new NotImplementedException("TEST");

        var student = await _dbContext.Students.Where(x => x.Id == request.Id).Select(x => new StudentDto
        {
            Id = x.Id,
            Name = x.Name,
        }).FirstOrDefaultAsync(cancellationToken);

        if (student == null)
        {
            throw new NotFoundCustomException("Item not found");
        }

        return student;
    }
}
