using AutoMapper;
using CodeCrafts.Domain.Entities;

namespace Application.StudentTopic.Queries.GetStudents
{
    public class StudentDto // Todo Auto mapper
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}