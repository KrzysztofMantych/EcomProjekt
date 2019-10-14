using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class UserDataBasic
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    public class UserObjectBasic
    {
        public bool IsSuccess { get; set; }
        public List<UserDataBasic> Data { get; set; }
    }

}
