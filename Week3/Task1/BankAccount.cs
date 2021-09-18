using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Week3Task1.Models
{
    public class BankAccount
	{
		public long AccountNumber { get; set; }
		public decimal Balance { get; set; }
		public string AccountName { get; set; }
		public long RoutingNumber { get; set; }
		public int SwiftCode { get; set; }
		public AccountHolder AccHolder { get; set; }
		public int AccHolderId { get; set; }
		
	}
}
