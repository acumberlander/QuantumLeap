using QuantumLeap.cs.Models;
using System;
using Dapper;
using System.Data.SqlClient;

namespace QuantumLeap.cs.Data
{
    public class EventsRepository
    {

        const string ConnectionString = "Server=localhost;Database=SwordAndFather;Trusted_Connection=True";

        public Event AddEvent(string name, DateTime date)
        {
            using (var db = new SqlConnection(ConnectionString))
            {
                var newEvent = db.QueryFirstOrDefault(@"
                    Insert into events
                    Output inserted.*
                    Values(@name, @date)",
                    new { name, date });

                if (newEvent != null)
                {
                    return newEvent;
                }
            }
            throw new Exception("No event created");
        }
    }
}
