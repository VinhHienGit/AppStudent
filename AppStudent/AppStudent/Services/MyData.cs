using AppStudent.Models;
using Newtonsoft.Json;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PrismQuanLySinhVien.Services
{
    public interface IProductsMakeUpApi
    {
        [Get("/api/v1/products.json?brand=maybelline")]
        Task<string> GetMakeUps();
    }
    public class MyData
    {
        private List<Account> listAccount = new List<Account>();
        private List<Student> listStudent = new List<Student>();
        public MyData()
        {
            //create data Account
            Account admin = new Account()
            {
                Username = "admin123",
                Passwork = "123@123123",
                State = false
            };
            listAccount.Add(admin);
            listAccount.Sort();
            //create data student
           CallApi();
        }

        private static MyData instance;
        public static MyData Instance
        {
            get
            {
                if (instance == null) instance = new MyData();
                return instance;
            }

            private set
            {
                instance = value;
            }
        }

        public List<Student> ListStudent { get => listStudent; set => listStudent = value; }

        public bool CheckLogin(Account AccLogin)
        {
            int len = listAccount.Count;
            int x2 = len/2;
            bool IsAccount = false;
            while(len>0)
            {
                if (string.Compare(AccLogin.Username, listAccount[x2].Username) == 0)
                {
                    IsAccount = (AccLogin.Passwork == listAccount[x2].Passwork) ? true : false;
                    break;
                }
                else
                {
                    if (string.Compare(AccLogin.Username.ToString(), listAccount[x2].Username) > 0)
                    {
                        len = len / 2;
                        x2 += len / 2;
                    }
                    else
                    {
                        len = len / 2;
                        x2 -= (len / 2 == 0) ? 1 : (len / 2);
                    }
                }
            }
            return IsAccount;
        }

        private async void CallApi()
        {
            var nsAPI = RestService.For<IProductsMakeUpApi>("http://makeup-api.herokuapp.com");
            var products = await nsAPI.GetMakeUps();
            ListStudent = JsonConvert.DeserializeObject<List<Student>>(products.ToString());
        }


    }
}
