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
    public partial class Retrival : System.Web.UI.Page
    {             
        protected void Page_Load(object sender, EventArgs e)
        {
        
            if (!IsPostBack)
            {
                theDiv.Visible = false;
                DivTable.Visible = true;
                
                DataBindFunc(member_table, GridView_HMO_member);
                //gvbind();
            }
        }
        private string member_table = "SELECT * FROM HMO_member";
        private SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ApplicationDB"].ConnectionString);
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

               // return true;
            }
            catch(Exception error)
            {
                Clean_Add();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                    error.Message), true);
                //return false;              
            }
        }                  
        /// <summary>
        /// function for data binding to asp.net
        /// </summary>
        private void DataBindFunc(string table_sql, GridView grid_view)
        {
            try
            {
                conn.Open();
                DataSet data_set = new DataSet();
                StringBuilder str = new StringBuilder(table_sql);
                SqlCommand cmd = new SqlCommand(str.ToString(), conn);
                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(data_set);
                conn.Close();
                if (data_set.Tables[0].Rows.Count > 0)
                {
                    grid_view.DataSource = data_set;
                    grid_view.DataBind();
                }
                else
                {
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
            }

            catch (Exception error)
            {
                Clean_Add();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                    error.Message), true);
            }

        }

        /// <summary>
        /// API Gridview for Delete member
        /// </summary>
        protected void GridView_HMO_member_PageIndexChanging1(object sender, GridViewPageEventArgs e)
        {
            GridView_HMO_member.PageIndex = e.NewPageIndex;
            DataBindFunc(member_table, GridView_HMO_member);
        }
        protected void GridView_HMO_member_RowCancelingEdit1(object sender, GridViewCancelEditEventArgs e)
        {
            GridView_HMO_member.EditIndex = -1;
            DataBindFunc(member_table, GridView_HMO_member);
        }      
        protected void GridView_HMO_member_RowDeleting1(object sender, GridViewDeleteEventArgs e)
        {
            GridViewRow row = GridView_HMO_member.Rows[e.RowIndex];
            int memberid = Convert.ToInt32(GridView_HMO_member.DataKeys[e.RowIndex].Value.ToString());
            delete_dependent_tables(memberid);
            StringBuilder query = new StringBuilder("delete FROM HMO_member where code_HMO_member='" + memberid + "'");
            CmdExecute(query);
            DataBindFunc(member_table, GridView_HMO_member);
        }
       
        /// <summary>
        /// open popup for card of member
        /// </summary>
        protected void GridView_HMO_member_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Get_Corone_Member")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int ID = Convert.ToInt32(GridView_HMO_member.DataKeys[index].Value);
                string url = "RecordForm.aspx";
                string s = "window.open('" + url + "?ID=" + ID + "', 'popup_window', 'width=800,height=700,left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
        }
       
        /// <summary>
        /// validate inputs before save
        /// </summary>
        private bool validate_input_before_save()
        {
            if (!ValidateFunction.Isfull_name(full_name.Text))
            {
                throw new Exception("Error! the name is only alph bet in english");
            }
            if (!ValidateFunction.IsID(identity_card.Text))
            {
                throw new Exception("Error! ID is only 9 digitis");
            }
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
                throw new Exception("Error! phone only 9 digitis");
            }
            if (!ValidateFunction.IsDateTime(date_birth.Text))
            {
                throw new Exception("Error! date birth is only format YYYY-MM-DD");
            }
            return true;
        }

        /// <summary>
        /// Save Member in DB
        /// </summary>
        protected void ButtonSaveMember_Click(object sender, EventArgs e)
        {
            try
            {
                validate_input_before_save();
             
                StringBuilder str = create_query_add_member();
                CmdExecute(str);
                DataBindFunc(member_table, GridView_HMO_member);
                theDiv.Visible = false;
                DivTable.Visible = true;
            }
            catch (Exception error)
            {
                Clean_Add();
                this.Page.ClientScript.RegisterStartupScript(typeof(string), "key", string.Format("alert('{0}');",
                  error.Message), true);
            }
        }
        private StringBuilder create_query_add_member()
        {
           
            StringBuilder query_add_member = new StringBuilder("INSERT INTO CoronaDB.dbo.HMO_member Values(");
            if (full_name.Text != "")
                //ERROR
                query_add_member.Append("'" + full_name.Text + "', ");
            else
                throw new Exception("Error!  You did not enter an full name");                       
            if (identity_card.Text != "")
                //ERROR
                query_add_member.Append(identity_card.Text + " , ");
            else
                throw new Exception("Error!  You did not enter an ID");


            if (address.Text != "")
                query_add_member.Append("'" + address.Text + "', ");
            else
                query_add_member.Append("NULL,");
            if (mobile_phone.Text != "")
                query_add_member.Append("'" + mobile_phone.Text + "', ");
            else
                query_add_member.Append("NULL,");
            if (phone.Text != "")
                query_add_member.Append("'" + phone.Text + "', ");
            else
                query_add_member.Append("NULL,");
            if (date_birth.Text != "")
                query_add_member.Append("'" + date_birth.Text + "' )");
            else
                query_add_member.Append("NULL)");
            return query_add_member;
        }
    
        /// <summary>
        /// open popup for card of member
        /// </summary>
        private void Open_Member_Card(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Get_Corone_Member")
            {
                int index = Convert.ToInt32(e.CommandArgument);
                int ID = Convert.ToInt32(GridView_HMO_member.DataKeys[index].Value);
                string url = "RecordForm.aspx";
                string s = "window.open('" + url + "?ID=" + ID + "', 'popup_window', 'width=800,height=700,left=100,top=100,resizable=yes');";
                ClientScript.RegisterStartupScript(this.GetType(), "script", s, true);
            }
        }

          
        /// <summary>
        /// function for before delete member need delete 2 tables related to member
        /// </summary>
        private void delete_dependent_tables(int memberid)
        {
            StringBuilder query_delete1, query_delete2;
            query_delete1 = new StringBuilder("delete FROM positive_corona_member where code_HMO_member='" + memberid + "'");
            query_delete2 = new StringBuilder("delete FROM vaccination_member_details where code_HMO_member='" + memberid + "'");
            CmdExecute(query_delete1);
            CmdExecute(query_delete2);

        }

        /// <summary>
        /// function for clearing the fields:
        /// </summary>
        private void Clean_Add()
        {
            full_name.Text = "";
            identity_card.Text = "";
            address.Text = "";
            mobile_phone.Text = "";
            phone.Text = "";
            date_birth.Text = "";
        }

        /// <summary>
        /// for display 
        /// </summary>
        protected void ButtonAddMember_Click(object sender, EventArgs e)
        {
            theDiv.Visible = true;
            DivTable.Visible = false;
        }

        /// <summary>
        /// back to hmo table and exit for the popup for add member
        /// </summary>
        protected void ButtonBack_Click(object sender, EventArgs e)
        {
            Clean_Add();
            theDiv.Visible = false;
            DivTable.Visible = true;
        }

    }
}