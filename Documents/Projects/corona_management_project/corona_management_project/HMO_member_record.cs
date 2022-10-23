using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace corona_management_project
{

    public class HMO_member_record
    {
        private int code;
        private string full_name;
        private string id;

        public int Code { get => code; set => code = value; }
        public string Full_name { get => full_name; set => full_name = value; }
        public string Id { get => id; set => id = value; }
    }
}