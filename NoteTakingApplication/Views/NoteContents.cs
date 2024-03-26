using System;
using System.Text.Json;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using NoteTakingApplication.Data;
using NoteTakingApplication.OutputTexts;


namespace NoteTakingApplication.Views;

public class NoteContents
{
    private Note _note = null;

    public NoteContents()
    {
        
    }

    public void RunNoteContentsViews(int UserId)
    {

        string filepath = @"";  string userstring = UserId.ToString();
        filepath += userstring;
        filepath += ".json";

        if (File.Exists(filepath))
        {
            string noteString = File.ReadAllText(filepath);

            List<Note> myNotes = new List<Note>();
            myNotes = JsonConvert.DeserializeObject<List<Note>>(noteString);

            Console.WriteLine(CommonOutputText.GetColumnHeading());

            for (int i = 0; i < myNotes.Count; i++)
            {
                Console.WriteLine($"{(i + 1).ToString().PadRight(4)}\t{myNotes[i].DateCreated.ToString().PadRight(20)}\t{myNotes[i].usernotes.ToString()}\n");
            }
        }
        else
            Console.WriteLine("You have not created any notes yet.");
    }
    public List<Note> UserNotes(int Userid)

    {
        string filepath = @""; string userstring = Userid.ToString();
        filepath += userstring;
        filepath += ".json";

        if (!File.Exists(filepath))
        {
            return new List<Note>();
            throw new FileNotFoundException("You currently have no notes created.");

        }

        try
        {
            string noteString = File.ReadAllText(filepath);

            List<Note> myNotes = new List<Note>();
            return JsonConvert.DeserializeObject<List<Note>>(noteString);
        }
        catch (Exception e)
        {
            Console.WriteLine($"You currently have no notes created.{e.Message}");
            return new List<Note>();
        }




    }
}