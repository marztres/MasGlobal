using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MasGlobal.Data.Entities;

namespace MasGlobal.Test
{
    [TestClass]
    public class EmployeeTest
    {
        [TestMethod]
        public void TestCalculatedHourlySalary()
        {
            var rng = new Random();
            var hourlySalary = rng.Next(100, 90000);
            var montlySalary = rng.Next(100, 90000);
            Employee hourlyEmploye = new Employee(
                                                  1, 
                                                  "Test name",
                                                  1,
                                                  "Administrator",
                                                  "Test description",
                                                  "HourlySalaryEmployee",
                                                  hourlySalary, 
                                                  montlySalary);

            var anualSalaryExpected = 120 * hourlySalary * 12;

            Assert.AreEqual(anualSalaryExpected, hourlyEmploye.AnualSalary);
        }

        [TestMethod]
        public void TestCalculatedMonthlylySalary()
        {
            var rng = new Random();
            var hourlySalary = rng.Next(1002, 90000);
            var montlySalary = rng.Next(1004, 60000);
            Employee monthlyEmploye = new Employee(
                                                  1,
                                                  "Test name",
                                                  1,
                                                  "Administrator",
                                                  "Test description",
                                                  "MonthlySalaryEmployee",
                                                  hourlySalary,
                                                  montlySalary);

            var anualSalaryExpected = montlySalary * 12;

            Assert.AreEqual(anualSalaryExpected, monthlyEmploye.AnualSalary);
        }
    }
}
