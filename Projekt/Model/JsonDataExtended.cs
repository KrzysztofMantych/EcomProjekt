using System;
using System.Collections.Generic;
using System.Text;

namespace Projekt
{
    public class UserDataExtended
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string City { get; set; }
    }

    public class UserObjectExtended
    {
        public bool IsSuccess { get; set; }
        public UserDataExtended Data { get; set; }
    }
}
