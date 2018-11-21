using AppStudent.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrismQuanLySinhVien.Services
{
    public class UserData
    {
        public List<Account> listAccount = new List<Account>();

        public UserData()
        {
            listAccount.Add(admin);
        }



        Account admin = new Account()
        {
            Username = "admin",
            Passwork = "123456",
            State = false
        };
    }
}
