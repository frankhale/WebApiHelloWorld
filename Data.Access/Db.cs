using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Linq;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;
using Data.Access.Models;

namespace Data.Access
{
	public class Db
	{
		private NorthWndDataClassesDataContext db;

		public Db()
		{
			db = new NorthWndDataClassesDataContext();
		}

		public IEnumerable<Data.Access.Models.Employee> GetEmployees()
		{
			var emps = from e in db.Employees
								 select new Models.Employee()
								 {
									 EmployeeId = e.EmployeeID,
									 LastName =  e.LastName,
									 FirstName = e.FirstName,
									 Title = e.Title,
									 TitleOfCourtesy = e.TitleOfCourtesy,
									 BirthDate = e.BirthDate,
									 HireDate = e.HireDate,
									 Address = e.Address,
									 City = e.City,
									 Region = e.Region,
									 PostalCode = e.PostalCode,
									 Country = e.Country,
									 HomePhone = e.HomePhone,
									 Extension = e.Extension,
									 Photo = e.Photo,
									 Notes = e.Notes,
									 ReportsTo = e.ReportsTo,
									 PhotoPath = e.PhotoPath
								 };

			return emps;
		}
	}
}
