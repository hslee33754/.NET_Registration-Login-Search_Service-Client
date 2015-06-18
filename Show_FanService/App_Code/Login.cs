using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// This class takes in the user name and password
/// retrieves information from the database
/// and then hashes the password and key to
/// see if it matches the database hash
/// </summary>
public class Login
{
	//class level variables-fields
    private string pass;
    private string username;
    private int seed;
    private byte[] dbhash;
    private int key;
    private byte[] newHash;
 
    //constructor takes in password and username
    public Login(string username, string pass)
    {
        this.username = username;
        this.pass = pass;
    }

    //gets the user info from the database
    private void GetUserInfo()
    {
        //declare the ADO Entities
        ShowTrackerEntities ste = new ShowTrackerEntities();
        
        //query the fields
        var info = from fl in ste.FanLogins
                   where fl.FanLoginUserName.Equals(username)
                   select new { fl.FanLoginKey, fl.FanLoginHashed, fl.FanLoginRandom };

        //loop through the results and assign the
        //values to the field variables
        foreach (var u in info)
        {
            seed = u.FanLoginRandom;
            dbhash = u.FanLoginHashed;
            key = u.FanLoginKey;
        }
    }

    private void GetNewHash()
    {
       //get the new hash
        PasswordHash h = new PasswordHash();
        newHash = h.HashIt(pass, seed.ToString());
    }

    private bool CompareHash()
    {
        //compare the hashes
        bool goodLogin = false;

        //if the hash doesn't exist
        //because not a valid user
        //the return will be false
        if (dbhash != null)
        {
            //if the hashes do match return true
            if (newHash.SequenceEqual(dbhash))
                goodLogin = true;
        }

        return goodLogin;

    }

    public int ValidateLogin()
    {
        //call the methods
        GetUserInfo();
        GetNewHash();
        bool result = CompareHash();

        //if the result is not true
        //set the key to 0
        if (!result)
            key = 0;

        return key;
    }
}