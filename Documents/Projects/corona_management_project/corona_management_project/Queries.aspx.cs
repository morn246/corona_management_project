﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.DataVisualization.Charting;
using System.Web.UI.WebControls;
using System.Xml;

namespace corona_management_project
{
    public partial class Queries : System.Web.UI.Page
    {
        public void xmlCreate()
        {
            XmlWriterSettings settings = new XmlWriterSettings();
            settings.Indent = true;
            XmlWriter writer = XmlWriter.Create(@"C:\Users\97252\Documents\Projects\corona_management_project\corona_management_project\LastMonth.xml", settings);

            writer.WriteStartDocument();

            writer.WriteComment("This file is generated by the program.");

            writer.WriteStartElement("Month");
            for (int i = 0; i < 30; i++)
            {
                writer.WriteStartElement("day");
                writer.WriteAttributeString("ID", graph_month.Arr_names[i]);
                writer.WriteElementString("Day", graph_month.Arr_names[i]);
                writer.WriteElementString("Amount", graph_month.Arr_month[i].ToString());
                writer.WriteEndElement();
            }

            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Flush();
            writer.Close();
        }
        class MonthArrNumVaccinated
        {
            private int[] arr_month = new int[30];
            private string[] arr_names = new string[30];
            public MonthArrNumVaccinated()
            {
                for (int i = 0; i < 30; i++)
                {
                    arr_month[i] = 0;
                    Arr_names[i] = (i + 1).ToString();

                }
            }

            public int[] Arr_month { get => arr_month; set => arr_month = value; }
            public string[] Arr_names { get => arr_names; set => arr_names = value; }
        }
        private MonthArrNumVaccinated graph_month;


        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDB"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                StringBuilder query = new StringBuilder("select * from CoronaDB.dbo.vaccination_member_details V" +
       " where MONTH(V.vaccination_date) = MONTH(getdate()) and" +
       " YEAR(V.vaccination_date) = YEAR(getdate())");
                GetData(query.ToString(), 2);
                xmlCreate();

            }
            NumNotVaccinatedMember.Enabled = false;
        }
        private void GetData(string query, int num)
        {
            conn.Open();
            DataSet data_set = new DataSet();
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataReader OReader = cmd.ExecuteReader();
            graph_month = new MonthArrNumVaccinated();
            while (OReader.Read())
            {
                if (num == 1)
                    NumNotVaccinatedMember.Text = OReader["number_not_vaccinated"].ToString();
                else if (num == 2)
                {

                    DateTime d = Convert.ToDateTime(OReader["vaccination_date"].ToString());
                    graph_month.Arr_month[d.Day] += 1;


                }
            }
            conn.Close();
        }

        protected void ButtonNumNotVaccinatedMember_Click(object sender, EventArgs e)
        {
            StringBuilder query = new StringBuilder("select Count(C.code_HMO_member) as number_not_vaccinated" +
            " from CoronaDB.dbo.HMO_member C" +
            " where C.code_HMO_member not in (SELECT V.code_HMO_member" +
             " from CoronaDB.dbo.vaccination_member_details V)");
            GetData(query.ToString(), 1);
        }

        protected void ButtonPatientGraphLastMonth_Click1(object sender, EventArgs e)
        {
            string url = "GraphMonthChart.aspx";
            string s = "window.open('" + url + "?ID=" + ID + "', 'popup_window', 'width=800,height=700,left=100,top=100,resizable=yes');";
            ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);

        }
    }
}