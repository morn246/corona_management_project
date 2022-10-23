using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace corona_management_project
{
    public partial class RecordForm1 : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            string id_member = Request.QueryString["ID"];
            id = int.Parse(id_member);

            if (!IsPostBack)
            {
                DivAddVaccination.Visible = false;
                DivAddPositivaCorona.Visible = false;
                string str_query ="select * FROM CoronaDB.dbo.HMO_member where code_HMO_member =" + id;
                GetDate(str_query, 1);
                NameMember.InnerText = "Name Member: " + Member.Full_name; 
                IdMember.InnerText = "ID: " + Member.Id;

                DataBindFunc(vc_table1, GridViewVaccination, 1);
                DataBindFunc(corona_table2, GridViewCorona, 2);
                DataBindFunc(member_table3, GridViewHmoMember, 3);

            }
        }
        private int id;
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDB"].ConnectionString);
        private string member_table3 = "SELECT * FROM HMO_member where code_HMO_member =";
        private string vc_table1 = "select * from CoronaDB.dbo.vaccination_member_details where code_HMO_member =";
        private string corona_table2 = "SELECT * FROM CoronaDB.dbo.positive_corona_member where code_HMO_member =";
        HMO_member_record Member= new HMO_member_record();
        /// <summary>
        /// function for Insert/Delete/update after check the validate and correct inputs
        /// </summary>
        private void CmdExecute(StringBuilder cmd_text)
        {
            try
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(cmd_text.ToString(), conn);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            catch (Exception error)
            {
               
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                    error.Message), true);             
            }
        }
        /// <summary>
        /// function for data binding to asp.net
        /// </summary>
        private void DataBindFunc(string table_sql, GridView grid_view, int num)
        {
            try
            {
                conn.Open();
                DataSet data_set = new DataSet();
                StringBuilder str = new StringBuilder(table_sql+id);
                SqlCommand cmd = new SqlCommand(str.ToString(), conn);
                SqlDataAdapter date_adapter = new SqlDataAdapter(cmd);
                date_adapter.Fill(data_set);
                conn.Close();
                if (data_set.Tables[0].Rows.Count > 0)
                {
                    grid_view.DataSource = data_set;
                    grid_view.DataBind();
                    if (num == 1)
                    {
                        DataSet ds_manufacturer = ManufacturerDropDownList_Selected();
                        conn.Open();
                        SqlDataReader oReader1 = cmd.ExecuteReader();
                        int i = 0;
                        while (oReader1.Read())
                        {
                            DropDownList manufacturer_ddlEdit = GridViewVaccination.Rows[i].FindControl("ManufacturerDropDownListEdit") as DropDownList;
                            manufacturer_ddlEdit.DataSource = ds_manufacturer;
                            manufacturer_ddlEdit.DataTextField = "name_manufacturer";
                            manufacturer_ddlEdit.DataValueField = "code_manufacturer";
                            i++;
                            manufacturer_ddlEdit.SelectedValue = oReader1["code_manufacturer"].ToString();
                            manufacturer_ddlEdit.DataBind();

                            manufacturer_ddlEdit.Enabled = false;

                        }
                        conn.Close();
                    }
                    else if (num == 2)
                    {
                        DivAddCoronaButton.Visible = false;
                        DivAddPositivaCorona.Visible = false;
                        DivPositivaCoronaTable.Visible = true;
                    }
                }
                else
                {
                    if (num == 2)
                    {
                        DivAddCoronaButton.Visible = true;
                        DivAddPositivaCorona.Visible = false;
                        DivPositivaCoronaTable.Visible = true;
                    }
                    data_set.Tables[0].Rows.Add(data_set.Tables[0].NewRow());
                    grid_view.DataSource = data_set;
                    grid_view.DataBind();
                    int columncount = grid_view.Rows[0].Cells.Count;
                    grid_view.Rows[0].Cells.Clear();
                    grid_view.Rows[0].Cells.Add(new TableCell());
                    grid_view.Rows[0].Cells[0].ColumnSpan = columncount;
                    grid_view.Rows[0].Cells[0].Text = " Empty Records ";
                }
                //return true;
                if (num == 1)
                {
                    if (data_set.Tables[0].Rows.Count < 4)
                    {
                        DivButtonAddVc.Visible = true;
                        DivAddVaccination.Visible = false;
                        DivVaccinationTable.Visible = true;

                    }
                    else
                    {
                        DivButtonAddVc.Visible = false;
                        DivAddVaccination.Visible = false;
                        DivVaccinationTable.Visible = true;
                    }
                }                        
            }

            catch (Exception error)
            {               
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                    error.Message), true);
            }
        }
        /// <summary>
        /// create DropDown list of Manufacturer
        /// </summary>
        private DataSet ManufacturerDropDownList_Selected()
        {
            string query = "SELECT M.code_manufacturer,M.name_manufacturer  FROM manufacturer_table M";
            conn.Open();
            StringBuilder str = new StringBuilder(query);
            SqlCommand cmd = new SqlCommand(str.ToString(), conn);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);
            conn.Close();
            return ds;
        }
        /// <summary>
        /// Get Date from db in hmo member
        /// </summary>
        private bool  GetDate(string query, int num)
        {
            try
            {
                conn.Open();
                DataSet data_set = new DataSet();
                StringBuilder str1 = new StringBuilder(query);
                SqlCommand cmd = new SqlCommand(str1.ToString(), conn);
                SqlDataReader OReader = cmd.ExecuteReader();
                while (OReader.Read())
                {
                    if (num == 1)
                    {
                        Member.Full_name = OReader["full_name"].ToString();
                        Member.Id = OReader["identity_card"].ToString();
                    }
                    if (num == 2)
                    {
                        return false;
                    }
                }
                conn.Close();
                return true;
            }
            catch (Exception error)
            {
                conn.Close();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                    error.Message), true);
                return false;              
            }

        }

  
        /// /// <summary>
        /// API Gridview for edit and delete vc
        /// </summary>
        protected void GridViewVaccination_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            DateTime d = Convert.ToDateTime(GridViewVaccination.DataKeys[e.RowIndex].Value);
            StringBuilder query_delete = new StringBuilder("delete CoronaDB.dbo.vaccination_member_details where code_HMO_member="
                + id + " and CoronaDB.dbo.vaccination_member_details.vaccination_date= '" +
                d.ToString("yyyy-MM-dd") + "'");
            CmdExecute(query_delete);  
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);
        }
        protected void GridViewVaccination_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewVaccination.EditIndex = e.NewEditIndex;
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);

            DropDownList manufacturer_ddlEdit = GridViewVaccination.Rows[e.NewEditIndex].FindControl("ManufacturerDropDownListEdit") as DropDownList;
            manufacturer_ddlEdit.Enabled = true;
            TextBox t = (TextBox)GridViewVaccination.Rows[e.NewEditIndex].Cells[0].Controls[0];
            t.Enabled = false;
        }
        protected void GridViewVaccination_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {           
            DateTime dateid = Convert.ToDateTime(GridViewVaccination.DataKeys[e.RowIndex].Value.ToString());
            string stringDate = dateid.ToString("yyyy-MM-dd");
            GridViewRow row = (GridViewRow)GridViewVaccination.Rows[e.RowIndex];
            //Label lblID = (Label)row.FindControl("lblID");
            //TextBox txtname=(TextBox)gr.cell[].control[];  
            TextBox vaccination_date = (TextBox)row.Cells[0].Controls[0];
            DropDownList code_manufacturer = row.FindControl("ManufacturerDropDownListEdit") as DropDownList;
           
            GridViewVaccination.EditIndex = -1;
            conn.Open();
            //SqlCommand cmd = new SqlCommand("SELECT * FROM detail", conn);  
            SqlCommand cmd = new SqlCommand("update CoronaDB.dbo.vaccination_member_details"+
                " set CoronaDB.dbo.vaccination_member_details.code_manufacturer='"+code_manufacturer.SelectedValue + "'"+
                " where CoronaDB.dbo.vaccination_member_details.code_HMO_member='" + id +"'"+
                " and CoronaDB.dbo.vaccination_member_details.vaccination_date='" + stringDate + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);
        }
        protected void GridViewVaccination_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewVaccination.PageIndex = e.NewPageIndex;
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);

        }
        protected void GridViewVaccination_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewVaccination.EditIndex = -1;
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);
        }

        /// /// <summary>
        /// API Gridview for edit and delete corona member
        /// </summary>
        protected void GridViewCorona_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = (GridViewRow)GridViewCorona.Rows[e.RowIndex];
            //Label lbldeleteid = (Label)row.FindControl("lblID");
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete CoronaDB.dbo.positive_corona_member where code_HMO_member='"
                + id + "'", conn);
            cmd.ExecuteNonQuery();
            conn.Close();
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);

        }
        protected void GridViewCorona_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewCorona.EditIndex = e.NewEditIndex;
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);
        }           
        protected void GridViewCorona_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)GridViewCorona.Rows[e.RowIndex];
                GridViewCorona.EditIndex = -1;
                StringBuilder query_update=validate_corona_update(row);                          
                CmdExecute(query_update);
                DataBindFunc(vc_table1, GridViewVaccination, 1);
                DataBindFunc(corona_table2, GridViewCorona, 2);
            }
            catch (Exception error)
            {               
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                  error.Message), true);
            }
        }
        protected void GridViewCorona_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewCorona.PageIndex = e.NewPageIndex;

            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);

        }
        protected void GridViewCorona_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewCorona.EditIndex = -1;
            DataBindFunc(vc_table1, GridViewVaccination, 1);
            DataBindFunc(corona_table2, GridViewCorona, 2);
        }
             
        /// <summary>
        /// API Gridview for edit member
        /// </summary>
        protected void GridViewHmoMember_RowEditing(object sender, GridViewEditEventArgs e)
        {
            GridViewHmoMember.EditIndex = e.NewEditIndex;      
            DataBindFunc(member_table3, GridViewHmoMember, 3);
        
        }    
        protected void GridViewHmoMember_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            try
            {
                GridViewRow row = (GridViewRow)GridViewHmoMember.Rows[e.RowIndex];
                StringBuilder query_udate= validate_and_create_query_update(row);                         
                GridViewHmoMember.EditIndex = -1;
                CmdExecute(query_udate);
                DataBindFunc(member_table3, GridViewHmoMember, 3);
            }
            catch(Exception error)
            {
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                     error.Message), true);
            }
        }
        protected void GridViewHmoMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridViewHmoMember.PageIndex = e.NewPageIndex;
            DataBindFunc(member_table3, GridViewHmoMember, 3);
   
        }
        protected void GridViewHmoMember_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            GridViewHmoMember.EditIndex = -1;
            DataBindFunc(member_table3, GridViewHmoMember, 3);
      
        }       

        /// <summary>
        /// validate and save record form of member
        /// </summary>
        protected void btnSave_vaccination_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder str1 = validate_before_and_create_query_add_vc();
                CmdExecute(str1);
                clean_add_vc();
                DivAddVaccination.Visible = false;
                DivVaccinationTable.Visible = true;
                DataBindFunc(vc_table1, GridViewVaccination, 1);
            }
            catch (Exception error)
            {
                clean_add_vc();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                  error.Message), true);
            }

        }
        /// <summary>
        /// validate and save record form of corona
        /// </summary>
        protected void btnSave_Corona_Click(object sender, EventArgs e)
        {
            try
            {
                StringBuilder query_add = validate_before_and_create_query_add_corona();
                CmdExecute(query_add);
                DataBindFunc(corona_table2, GridViewCorona, 2);
            }
            catch (Exception error)
            {
                clean_add_vc();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                  error.Message), true);
                DataBindFunc(corona_table2, GridViewCorona, 2);
            }
        }


        /// <summary>
        /// validate before adding corona and create query
        /// </summary>
        private StringBuilder validate_before_and_create_query_add_corona()
        {
            StringBuilder query = new StringBuilder("INSERT INTO CoronaDB.dbo.positive_corona_member Values(" + id + " , ");
            validate_corona_dates(date_positive_corona, date_recovery_corona);
            if (date_recovery_corona.Text != "")
                query.Append("'" + date_recovery_corona.Text + "', ");
            else
                query.Append("NULL, ");
            if (date_positive_corona.Text != "")
                query.Append("'" + date_positive_corona.Text + "' ) ");
            else
                query.Append("NULL)");
          
            return query;
        }
        /// <summary>
        /// Avalidate of dates of corona and create query
        /// </summary>
        public void validate_corona_dates(TextBox date_positive_corona, TextBox date_recovery_corona)
        {
            if (date_recovery_corona.Text == "" && date_positive_corona.Text == "")
            {
                throw new Exception("Error! the fileds is empty");
            }
            if (!ValidateFunction.IsDateTime(date_positive_corona.Text))
            {
                //error
                throw new Exception("Error! date positive is only format YYYY-MM-DD");
            }
            if (!ValidateFunction.IsDateTime(date_recovery_corona.Text))
            {
                //error
                throw new Exception("Error! date recovery is only format YYYY-MM-DD");
            }

        }
        private StringBuilder validate_corona_update(GridViewRow row)
        {
            TextBox date_positive_corona = (TextBox)row.Cells[0].Controls[0];
            TextBox date_recovery_corona = (TextBox)row.Cells[1].Controls[0];
            validate_corona_dates(date_positive_corona, date_recovery_corona);
            string date_positive_corona1 = "NULL";
            string date_recovery_corona1 = "NULL";
            if (date_positive_corona.Text != "")
                date_positive_corona1 = "'" + DateTime.Parse(date_positive_corona.Text).ToString("yyyy-MM-dd") + "'";
            if (date_recovery_corona.Text != "")
                date_recovery_corona1 = "'" + DateTime.Parse(date_recovery_corona.Text).ToString("yyyy-MM-dd") + "'";

            StringBuilder query_update = new StringBuilder("update CoronaDB.dbo.positive_corona_member set date_recovery_corona= " +
              date_recovery_corona1 + " , date_positive_corona=" +
              date_positive_corona1 + " where code_HMO_member='" + id + "'");
            return query_update;
        }
        /// <summary>
        /// validate inputs of adding member
        /// </summary>
        private StringBuilder validate_and_create_query_update(GridViewRow row)
        {
            TextBox address = (TextBox)row.Cells[0].Controls[0];
            TextBox mobile_phone = (TextBox)row.Cells[1].Controls[0];
            TextBox phone = (TextBox)row.Cells[2].Controls[0];
            TextBox date_birth = (TextBox)row.Cells[3].Controls[0];

            if (!ValidateFunction.IsAlphbetAndNum(address.Text))
            {
                throw new Exception("Error! address is only alph bet in english and numbers");
            }
            if (!ValidateFunction.IsPhoneNbr(mobile_phone.Text))
            {
                throw new Exception("Error! phone only 10 digitis");
            }
            if (!ValidateFunction.IsPhoneNbr(phone.Text))
            {
                throw new Exception("Error! phone only 10 digitis");
            }
            if (!ValidateFunction.IsDateTime(date_birth.Text))
            {
                throw new Exception("Error! date_birth is only format YYYY-MM-DD");
            }

            string phone1 = (phone.Text).Replace(" ", String.Empty);
            string mobile_phone1 = (mobile_phone.Text).Replace(" ", String.Empty);
            string date_birth1 = "NULL";
            if (date_birth.Text != "")
                date_birth1 = "'" + DateTime.Parse(date_birth.Text).ToString("yyyy-MM-dd") + "'";
            StringBuilder str = new StringBuilder("update CoronaDB.dbo.HMO_member set address='" +
                    address.Text + "' ,mobile_phone= '" + mobile_phone1 + "' , phone= '" + phone1 + "' , date_birth=" +
                    date_birth1 + " where code_HMO_member='" + id + "'");
            return str;
        }
        /// <summary>
        /// validate inputs of adding vc
        /// </summary>
        private StringBuilder validate_before_and_create_query_add_vc()
        {
            StringBuilder str1 = new StringBuilder("INSERT INTO CoronaDB.dbo.vaccination_member_details Values(" + id + " , ");
            if (vaccination_date.Text != "")
                str1.Append("'" + vaccination_date.Text + "', ");
            else
                throw new Exception("Error! Must enter a vaccination date");
            if (!ValidateFunction.IsDateTime(vaccination_date.Text))
            {
                throw new Exception("Error! vaccination of date is only format YYYY-MM-DD");
            }
           
            StringBuilder str = new StringBuilder("select * FROM CoronaDB.dbo.vaccination_member_details V "
                        + "where  V.code_HMO_member =" + id + " and vaccination_date= '" + vaccination_date.Text + "'");

           if( GetDate(str.ToString(),2)==false)
                throw new Exception("Error! You have 2 identical vaccination dates! ");
                     
            if (ManufacturerDropDownList.Text != "")
                str1.Append(ManufacturerDropDownList.Text + " ) ");
            else
                str1.Append("NULL)");
            return str1;
        }

        /// <summary>
        /// funcation of cleaning fields
        /// </summary>
        private void clean_add_vc()
        {
            vaccination_date.Text = "";
            ManufacturerDropDownList.ClearSelection();
        }
        private void clean_add_corona()
        {
            date_positive_corona.Text = "";
            date_recovery_corona.Text = "";
        }

        /// <summary>
        /// button when press it is back to member card
        /// </summary>
        protected void Back_Click_Corona(object sender, EventArgs e)
        {
            clean_add_corona();
            DivAddPositivaCorona.Visible = false;
            DivPositivaCoronaTable.Visible = true;
        }        
        /// <summary>
        /// button when to add dates of corona
        /// </summary>
        protected void Add_corona_Click(object sender, EventArgs e)
        {
            DivAddPositivaCorona.Visible = true;
            DivPositivaCoronaTable.Visible = false;
        }
        /// <summary>
        /// button of back to record form of member 
        /// </summary>     
        protected void Back_Click(object sender, EventArgs e)
        {
            clean_add_vc();
            DivAddVaccination.Visible = false;
            DivVaccinationTable.Visible = true;
        }
        /// <summary>
        /// button when press add vc
        /// </summary>
        protected void Add_vc_Click(object sender, EventArgs e)
        {
            ManufacturerDropDownList.DataSource = ManufacturerDropDownList_Selected();
            ManufacturerDropDownList.DataTextField = "name_manufacturer";
            ManufacturerDropDownList.DataValueField = "code_manufacturer";
            ManufacturerDropDownList.DataBind();

            DivAddVaccination.Visible = true;
            DivVaccinationTable.Visible = false;
        }
    }
}