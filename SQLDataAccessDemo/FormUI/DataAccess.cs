using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace FormUI
{
  public class DataAccess
  {
    public List<Person> GetPeople(string lastName)
    {
      using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PeopleDBConnection")))
      {
        var output = connection.Query<Person>($"select * from People where LastName = '{lastName}'").ToList();
        return output;
      }
    }

    public void InsertPerson(string firstName, string lastName, string emailAddress, string phoneNumber)
    {
      using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("PeopleDBConnection")))
      {
        List<Person> people = new List<Person>();
        people.Add(new Person { FirstName = firstName, LastName = lastName, EmailAddress = emailAddress, PhoneNumber = phoneNumber });
        connection.Execute($"INSERT INTO People (FirstName, LastName, EmailAddress, PhoneNumber)\r\nVALUES ('{firstName}', '{lastName}', '{emailAddress}', '{phoneNumber}')");
      }
    }
  }
}
