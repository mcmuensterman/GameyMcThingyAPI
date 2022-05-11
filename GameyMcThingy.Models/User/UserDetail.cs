using System;

namespace GameyMcThingy.Models.User
{
	public class UserDetail
	{
		public int Id { get; set; }
		public string Username { get; set; }
		public string Email { get; set; }
		public DateTime DateCreated { get; set; }
	}
}