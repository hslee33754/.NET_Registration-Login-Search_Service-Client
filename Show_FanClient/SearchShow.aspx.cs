using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FanService;

public partial class SearchShow : System.Web.UI.Page
{
    FanServiceClient fc = new FanServiceClient();

    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["Id"]==null)
        {
            Response.Redirect("Default.aspx");
        }
        if (!IsPostBack)
        {
            FillArtistList();
            FillGenreList();   
        }
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = DropDownList1.SelectedItem.Text;
        ShowLite[] shs = fc.GetShows(selected);

        GridView1.DataSource = shs.ToList();
        GridView1.DataBind();

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        string selected = DropDownList2.SelectedItem.Text;
        ShowLite[] shs = fc.GetShows(selected);

        GridView1.DataSource = shs.ToList();
        GridView1.DataBind();
    }

    private void FillArtistList()
    {
        Artist[] arts = fc.GetArtist();

        DropDownList1.DataSource = arts.ToList();
        DropDownList1.DataTextField = "ArtistName";
        DropDownList1.DataValueField = "ArtistKey";
        DropDownList1.DataBind();
    }

    private void FillGenreList()
    {
        Genre[] genres = fc.GetGenre();

        DropDownList2.DataSource = genres.ToList();
        DropDownList2.DataTextField = "GenreName";
        DropDownList2.DataValueField = "GenreKey";
        DropDownList2.DataBind();
    }
}