using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

// NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IFanService" in both code and config file together.
[ServiceContract]
public interface IFanService
{
    [OperationContract]
    bool FanRegister(Fan f, FanLogin fl);

    [OperationContract]
    int FanLogin(string UserName, string Password);

    [OperationContract]
    List<Artist> GetArtist();

    [OperationContract]
    List<Genre> GetGenre();

    [OperationContract]
    List<ShowLite> GetShows(string selected);
}

[DataContract]
public class ShowLite
{
    [DataMember]
    public string ShowTitle { set; get; }

    [DataMember]
    public DateTime Date { set; get; }

    [DataMember]
    public TimeSpan Time { set; get; }

    [DataMember]
    public string Ticketinfo { set; get; }

    [DataMember]
    public TimeSpan ArtistStartTime { set; get; }

    [DataMember]
    public string Additional { set; get; }

    [DataMember]
    public string Artist { set; get; }

    [DataMember]
    public string Venue { set; get; }

    [DataMember]
    public string Genre { set; get; }

}
