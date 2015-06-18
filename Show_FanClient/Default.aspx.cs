using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        //instantiate the service
        FanService.FanServiceClient fc = new FanService.FanServiceClient();

        //call the method
        int id = fc.FanLogin(txtUserName.Text, txtPassword.Text);

        //check the results
        if (id != 0)
        {
            //if the key is not 0 save it to a session
            Session["id"] = id;
            //redirect to the welcome page
            Response.Redirect("SearchShow.aspx");
        }
        else
        {
            //otherwise give an error messages
            lblResult.Text = "Invalid Log in";
        }
    }
}