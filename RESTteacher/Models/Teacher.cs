namespace RESTteacher.Models
{
    public class Teacher : ITeacher
    {

        public Teacher()
        {
            Id = -1;
            Name = null;
            Salary = 0;
        }

        public int Id { get; set; }

        public string? Name { get; set; }
 
        public int Salary { get; set; }

        public override string ToString()
        {
            return Id + " " + Name + " " + Salary;
        }
    }
}
