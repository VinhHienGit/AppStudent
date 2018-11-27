using Prism.Commands;
using PrismQuanLySinhVien.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppStudent.Models
{
    public interface IApplicationCommands
    {
        CompositeCommand LogoutCommand { get; }
    }

    public class ApplicationCommands : IApplicationCommands
    {
        private readonly CompositeCommand _logoutCommand = new CompositeCommand();
        public CompositeCommand LogoutCommand
        {
            get
            {
                return _logoutCommand;
            }
        }
    }

    public interface IApplicationDatas
    {
        Account User { get; set; }
    }

    public class ApplicationDatas: IApplicationDatas
    {
        Account _User = new Account();

        public Account User
        { get => _User; set => _User = value; }
    }
    


}
