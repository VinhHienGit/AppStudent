using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppStudent.Models
{
    public class Student
    {
        public Student()
        {
            Email = "nguyenzone95@gamil.com";
            Phone = "0338122366";
        }
        public string Phone { get; set; }
        public string Email { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image_link { get; set; }
        public string Description { get; set; }
        public DateTime Created_at { get; set; }
    }
}
