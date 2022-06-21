namespace RESTteacher.Models
{
    public static class TeackerValidator
    {
        public static void CheckName(String? name)
        {
            if (name == null) throw new ArgumentNullException(nameof(name));
            if (name.Length < 4)
                throw new ArgumentException("name must be at least 4 characters " + name);
        }

        public static void CheckSalary(int? salary)
        {
            if (salary == null) throw new ArgumentNullException(nameof(salary));
            if (salary < 0)
                throw new ArgumentOutOfRangeException("Salary", salary, "Salary must be at least 0");
        }
    }
}
