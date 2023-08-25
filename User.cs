﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_ADMIN
{
    /// <summary>
    /// An abstract class containing all user data.
    /// </summary>
    public abstract class User
    {
        public int Id { get; set; }
        public string Nick { get; set; }
        public string Password { get; set; }
        public string Login { get; set; }       


       
    }
}