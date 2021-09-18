using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3Task1.Models
{
    public class AccountHolder
	{
		public int AccountHolderId { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }
		public DateTime DateOfBirth { get; set; }
		public string Address { get; set; }
		public string Phone { get; set; }
		public List<BankAccount> BnkAccounts { get; set; }
		
	}
}
