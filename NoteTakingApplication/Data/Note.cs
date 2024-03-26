using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NoteTakingApplication.Data;

namespace NoteTakingApplication.Data;

public class Note
{

    public string usernotes { get; set; }

    public DateTime DateCreated { get; set; }

    public Note() 
    {
       
    }


    public Note(int userid, string noteContent)
    {
        usernotes = noteContent;
        DateCreated = DateTime.Now;
    }


}
