<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Register.aspx.cs" Inherits="Register" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <link href="Content/bootstrap.css" rel="stylesheet" />
    <link href="Content/bootstrap-theme.css" rel="stylesheet" />
    <!-- HTML5 shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!--[if lt IE 9]>
      <script src="../bower_components/html5shiv/dist/html5shiv.js"></script>
      <script src="../bower_components/respond/dest/respond.min.js"></script>
    <![endif]-->
    <script>

     var _gaq = _gaq || [];
      _gaq.push(['_setAccount', 'UA-23019901-1']);
      _gaq.push(['_setDomainName', "bootswatch.com"]);
        _gaq.push(['_setAllowLinker', true]);
      _gaq.push(['_trackPageview']);

     (function() {
       var ga = document.createElement('script'); ga.type = 'text/javascript'; ga.async = true;
       ga.src = ('https:' == document.location.protocol ? 'https://ssl' : 'http://www') + '.google-analytics.com/ga.js';
       var s = document.getElementsByTagName('script')[0]; s.parentNode.insertBefore(ga, s);
     })();

    </script>
</head>
<body>
     <div class="navbar navbar-default navbar-fixed-top">
      <div class="container">
        <div class="navbar-header">
          <a href="../" class="navbar-brand">Show Tracker</a>
          <button class="navbar-toggle" type="button" data-toggle="collapse" data-target="#navbar-main">
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
            <span class="icon-bar"></span>
          </button>
        </div>
        <div class="navbar-collapse collapse" id="navbar-main">
          <ul class="nav navbar-nav">
            <li>
              <a href="Register.aspx">Register</a>
            </li>
            <li>
              <a href="Default.aspx">Log in</a>
            </li>
            <li>
              <a href="SearchShow.aspx">Search Shows</a>
            </li>

          </ul>
        </div>
      </div>
    </div>

    <div class="container">
        <div class="bs-docs-section">
            <div class="row">
                <div class="col-lg-12">

                    <div class="page-header">
                        <h1 id="type">Show Tracker - Fan Registers Page</h1>
                    </div> <!-- End page header -->

                    <div class="bs-component">
                        <form id="form1" runat="server" class="form-horizontal">

        <table class="table table-hover ">
                <tr>
                    <td>Name</td>
                    <td>
                        <asp:TextBox ID="txtName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="NameReqValidator" runat="server" 
                            ControlToValidate="txtName" Display="None" ErrorMessage="Name is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Email</td>
                    <td>
                        <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="EamilExpressionValidator" runat="server" 
                            ControlToValidate="txtEmail" Display="None" ErrorMessage="Enter valid email" 
                            ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>UserName</td>
                    <td>
                        <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="UserNameReqValidator" runat="server" 
                            ControlToValidate="txtUserName" Display="None" 
                            ErrorMessage="User Name is required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>Password</td>
                    <td>
                        <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="PasswordReqValidator" runat="server" 
                            ControlToValidate="txtPassword" Display="None" ErrorMessage="Password Required"></asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td>ConfirmPassword</td>
                    <td>
                        <asp:TextBox ID="txtConfirm" runat="server"></asp:TextBox>
                        <asp:CompareValidator ID="PassCompareValidator" runat="server" 
                            ControlToCompare="txtPassword" ControlToValidate="txtConfirm" Display="None" 
                            ErrorMessage="Passwords don't match"></asp:CompareValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnRegister" runat="server" Text="Register" 
                            OnClick="btnRegister_Click" class="btn btn-default"/>
                    </td>
                    <td>
                        <asp:Label ID="lblError" runat="server" Text="Label"></asp:Label></td>
                </tr>
            </table>
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
        
            <p>
                <asp:LinkButton ID="LinkDefault" runat="server" PostBackUrl="~/Default.aspx">Log in</asp:LinkButton>
            </p>
        </form>
                    </div> <!-- End component -->

                </div> <!-- End column -->
            </div> <!-- End row -->
        </div> <!-- End bs doc section -->
    </div> <!-- End container -->

</body>
</html>
