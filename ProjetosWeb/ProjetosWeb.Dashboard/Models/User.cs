﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetosWeb.Dashboard.Models
{
    public class User
    {
        public Guid Id { get; set; }

        public String Username { get; set; }

        public String Email { get; set; }

        public String FirstName { get; set; }

        public String LastName { get; set; }

        public String Password { get; set; }

    }
}