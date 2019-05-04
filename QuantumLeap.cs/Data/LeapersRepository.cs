using Dapper;
using QuantumLeap.cs.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace QuantumLeap.cs.Data
{
    public class LeapersRepository
    {
        const string ConnectionString = "Server=localhost;Database=SwordAndFather;Trusted_Connection=True";

        public Leaper AddLeaper(string name)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newLeaper = db.QueryFirstOrDefault(@"
                    Insert into leapers
                    Output inserted.*
                    Values(@name)",
                    new { name });

                if (newLeaper != null)
                {
                    return newLeaper;
                }
            }
            throw new Exception("No leaper created");
        }

        public IEnumerable<Leaper> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var leapers = db.Query<Leaper>("Select name, age, id From leapers").ToList();

                var leapees = db.Query<Leapee>("Select * From Leapees").ToList();

                foreach(var leaper in leapers)
                {
                    var matchingLeapees = leapees
                        .Where(leapee => leapee.LeaperId == leaper.Id)
                        .ToList();
                }
                return leapers;
            }
        }
    }
}
