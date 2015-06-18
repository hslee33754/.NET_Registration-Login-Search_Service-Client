using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FanService" in code, svc and config file together.
public class FanService : IFanService
{
    ShowTrackerEntities ste = new ShowTrackerEntities();

    public bool FanRegister(Fan f, FanLogin fl)
    {
        bool result = true;
        try
        {
            PasswordHash ph = new PasswordHash();
            KeyCode kc = new KeyCode();
            int code = kc.GetHashCode();
            byte[] hashed = ph.HashIt(fl.FanLoginPasswordPlain, code.ToString());

            Fan fan = new Fan();
            fan.FanName = f.FanName;
            fan.FanEmail = f.FanEmail;
            fan.FanDateEntered = DateTime.Now;

            ste.Fans.Add(fan);

            FanLogin fanlogin = new FanLogin();
            fanlogin.Fan = fan;
            fanlogin.FanLoginDateAdded = DateTime.Now;
            fanlogin.FanLoginHashed = hashed;
            fanlogin.FanLoginPasswordPlain = fl.FanLoginPasswordPlain;
            fanlogin.FanLoginRandom = code;
            fanlogin.FanLoginUserName = fl.FanLoginUserName;

            ste.FanLogins.Add(fanlogin);
            ste.SaveChanges();
        }
        catch
        {
            result = false;
        }
        return result;
    }

    public int FanLogin(string UserName, string Password)
    {
        int id = 0;
        Login li = new Login(UserName, Password);
        id = li.ValidateLogin();

        return id;
    }

    public List<Artist> GetArtist()
    {
        var arts = from a in ste.Artists
                   orderby a.ArtistName
                   select new { a.ArtistName, a.ArtistKey };
        List<Artist> artists = new List<Artist>();
        foreach (var a in arts)
        {
            Artist at = new Artist();
            at.ArtistKey = a.ArtistKey;
            at.ArtistName = a.ArtistName;
            artists.Add(at);
        }
        return artists;
    }

    public List<Genre> GetGenre()
    {
        var gens = from g in ste.Genres
                   orderby g.GenreName
                   select new { g.GenreName, g.GenreKey };
        List<Genre> genres = new List<Genre>();
        foreach (var g in gens)
        {
            Genre gn = new Genre();
            gn.GenreKey = g.GenreKey;
            gn.GenreName = g.GenreName;
            genres.Add(gn);
        }
        return genres;
    }

    public List<ShowLite> GetShows(string selected)
    {       
        var shs = from a in ste.Artists
                  from sd in a.ShowDetails
                  from g in a.Genres
                  from s in ste.Shows
                  from v in ste.Venues
                  where 
                  s.ShowKey == sd.ShowKey &&
                  v.VenueKey == s.VenueKey &&
                  ( a.ArtistName == selected || g.GenreName == selected )
                  select new { s.ShowName, s.ShowDate, s.ShowTicketInfo, sd.ShowDetailAdditional, a.ArtistKey, a.ArtistName, s.ShowTime, sd.ShowDetailArtistStartTime, v.VenueName, g.GenreName };

        List<ShowLite> shows = new List<ShowLite>();
        foreach (var s in shs)
        {
            ShowLite sl = new ShowLite();
            sl.ShowTitle = s.ShowName;
            sl.Date = s.ShowDate;
            sl.Ticketinfo = s.ShowTicketInfo;
            sl.ArtistStartTime = s.ShowDetailArtistStartTime;
            sl.Additional = s.ShowDetailAdditional;
            sl.Artist = s.ArtistName;
            sl.Venue = s.VenueName;
            sl.Genre = s.GenreName;

            shows.Add(sl);
        }
        return shows;
    }
}
