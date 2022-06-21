using Microsoft.VisualStudio.TestTools.UnitTesting;
using RESTteacher.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RESTteacher.Models.Tests
{
    [TestClass()]
    public class TeacherTests
    {
        [TestMethod()]
        public void ToStringTest()
        {
            Teacher teacher = new Teacher() { Id = 1 };

            teacher.Name = "Bobo";
            Assert.AreEqual("Bobo", teacher.Name);
            Assert.ThrowsException<ArgumentException>(() => TeackerValidator.CheckName("Bob"));
            Assert.ThrowsException<ArgumentNullException>(() => TeackerValidator.CheckName(null));

            teacher.Salary = 0;
            Assert.AreEqual(0, teacher.Salary);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => TeackerValidator.CheckSalary(-1));

            Assert.AreEqual("1 Bobo 0", teacher.ToString());
        }
    }
}