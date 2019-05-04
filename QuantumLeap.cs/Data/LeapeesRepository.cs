using Dapper;
using QuantumLeap.cs.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace QuantumLeap.cs.Data
{
    public class LeapeesRepository
    {
        const string ConnectionString = "Server=localhost;Database=SwordAndFather;Trusted_Connection=True";

        public Leapee AddLeapee(string name, string job)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newLeapee = db.QueryFirstOrDefault(@"
                    Insert into leapees
                    Output inserted.*
                    Values(@name, @job)",
                    new { name, job });

                if (newLeapee != null)
                {
                    return newLeapee;
                }
            }
            throw new Exception("No leapee created");
        }
        public IEnumerable<Leapee> GetAll()
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var leapees = db.Query<Leapee>("select username, password, id from users").ToList();

                var leapers = db.Query<Leaper>("Select * from Leapers").ToList();

                foreach (var leapee in leapees)
                {
                    var matchingLeapers = leapers
                        .Where(leaper => leaper.LeapeeId == leapee.Id)
                        .ToList();
                }

                return leapees;
            }
        }
    }
}
