using System.Linq;
using ConsoleApp1.Model;
using ConsoleApp1.Model.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new PeopleContext();
            var data = db.People.Where(e => e.DateOfBirth <= DateTime.Today.Date).Take(14).ToList();
            
            Dictionary<string, Person> results = new Dictionary<string, Person>();
            DateTime currentDate = DateTime.Today.Date;
            for (int i = 1; i <= 14; i++)
            {
                results.Add(currentDate.Date.ToShortDateString(), null);
                currentDate = currentDate.AddDays(-1);
            }

            foreach (var record in data)
            {
                var key = record.DateOfBirth.Date;
                Person value;
                if (results.TryGetValue(key.ToShortDateString(), out value))
                {                    
                    results[record.DateOfBirth.ToShortDateString()] = record;
                }                
            }

            var viewModels = new List<PersonViewModel>();
            foreach (var key in results)
            {
                if (key.Value == null)
                {                    
                    viewModels.Add(new PersonViewModel { Name = "ABSENT", DateOfBirth=DateTime.Parse(key.Key) });
                }
                else
                {
                    var person = key.Value;
                    viewModels.Add(new PersonViewModel { Name = person.Name, DateOfBirth = person.DateOfBirth, PersonId = person.PersonId });
                }
            }
            PrintData(viewModels);
        }

        private static void PrintData(List<PersonViewModel> results)
        {
            foreach (var item in results)
            {
                Console.WriteLine($"{item.DateOfBirth} {item.Name}");
            }
        }
    }
}
