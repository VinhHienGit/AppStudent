using System;
using System.Collections.Generic;
using System.Text;

namespace AppStudent.Models
{
    public class Account
    {
        private string _username;
        private string _passwork;
        private bool _state;

        public Account()
        {

        }

        public string Username { get => _username; set => _username = value; }
        public string Passwork { get => _passwork; set => _passwork = value; }
        public bool State { get => _state; set => _state = value; }
    }
}
