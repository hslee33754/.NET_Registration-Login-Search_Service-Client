<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SearchShow.aspx.cs" Inherits="SearchShow" %>

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
                        <h1 id="type">Show Tracker - Search Show by artist/genre</h1>
                    </div> <!-- End page header -->

                    <div class="bs-component">
                        <form id="form1" runat="server" class="form-horizontal">
                            <div>
                                <p>Choose an artist to search shows</p>
        
                                <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="true" 
                                    OnSelectedIndexChanged="DropDownList1_SelectedIndexChanged"></asp:DropDownList>
                            </div>
                            <div>
                                <p>Choose a genre to search shows</p>
                                <asp:DropDownList ID="DropDownList2" runat="server" AutoPostBack="true" 
                                    OnSelectedIndexChanged="DropDownList2_SelectedIndexChanged"></asp:DropDownList>

                            </div>
                            <div>
                            <p></p>
                                <asp:GridView ID="GridView1" runat="server" class="table table-hover" ></asp:GridView>
                            </div>
                        </form>
                    </div> <!-- End component -->

                </div> <!-- End column -->
            </div> <!-- End row -->
        </div> <!-- End bs doc section -->
    </div> <!-- End container -->
</body>
</html>
