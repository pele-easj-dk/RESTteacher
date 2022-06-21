namespace RESTteacher.Models;

public interface ITeacher
{
    string? Name { get; set; }
    int Salary { get; set; }
    int Id { get; set; }
}