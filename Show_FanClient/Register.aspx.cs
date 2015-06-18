using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FanService;

public partial class Register : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void btnRegister_Click(object sender, EventArgs e)
    {
        //initiate service client
        FanServiceClient fc = new FanServiceClient();

        Fan f = new Fan();
        FanLogin fl = new FanLogin();

        //assign the values to the fields of the Fan Class

        f.FanName = txtName.Text;
        f.FanEmail = txtEmail.Text;
        fl.FanLoginUserName = txtUserName.Text;
        fl.FanLoginPasswordPlain = txtPassword.Text;

        bool result = fc.FanRegister(f, fl);

        if (result)
            lblError.Text = "Registration successful";
        else
            lblError.Text = "Registration failed";

    }
}