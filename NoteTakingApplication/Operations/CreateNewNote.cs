using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NoteTakingApplication.Data;
using NoteTakingApplication.OutputTexts;

namespace NoteTakingApplication.Operations;

public class CreateNewNote
{
    private Note notes;

    public CreateNewNote(Note _notes)
    {
        
    }

    public void DeleteNote(int userid, List<Note> Notes)
    {
        string dirpath = @""; string userstring = userid.ToString();
        string filePath = Path.Combine(dirpath, $"{userid}.json");

        string jsonString = JsonConvert.SerializeObject(Notes, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);

        Console.WriteLine("Note Deleted successfully!!");
    }

    public void UpdateNote(int userid, List<Note> Notes)
    {
        string dirpath = @""; string userstring = userid.ToString();
        string filePath = Path.Combine(dirpath, $"{userid}.json");

        string jsonString = JsonConvert.SerializeObject(Notes, Formatting.Indented);
        File.WriteAllText(filePath, jsonString);

        Console.WriteLine("Note Updated successfully!!");
    }

    public void RunNoteCreationOperation(int userid)
    {
        Console.WriteLine("Enter your note content: ");

        string NoteContent = Console.ReadLine();

        bool emptyNote = string.IsNullOrWhiteSpace(NoteContent);

        switch (emptyNote)
        {
            case false:
                Console.WriteLine(CommonOutputText.SaveDetailsMessage());

                string SaveDecision = Console.ReadLine().ToUpper();

                if (SaveDecision == "S")
                {

                    string dirpath = @""; string userstring = userid.ToString();
                    string filePath = Path.Combine(dirpath, $"{userid}.json");

                    List<Note> existingNotes = new List<Note>();

                    if (File.Exists(filePath))
                    {
                        string existingJson = File.ReadAllText(filePath);
                        existingNotes = JsonConvert.DeserializeObject<List<Note>>(existingJson);
                    }


                    notes = NoteTakingGeneralOperation.CreateNote(userid, NoteContent);

                    existingNotes.Add(notes);

                    string jsonString = JsonConvert.SerializeObject(existingNotes, Formatting.Indented);
                    File.WriteAllText(filePath, jsonString);

                    Console.WriteLine("Note Added successfully!!");
                }
                else if (SaveDecision != "S")
                {
                    break;
                }

                break;

            case true:
                Console.WriteLine(CommonOutputText.AddEmptyNoteMessage());
                Console.WriteLine(CommonOutputText.SaveDetailsMessage());

                string saveDecision = Console.ReadLine().ToUpper();
                if (saveDecision == "S")
                {
                    string dirpath = @""; string userstring = userid.ToString();
                    string filePath = Path.Combine(dirpath, $"{userid}.json");

                    List<Note> existingNotes = new List<Note>();

                    if (File.Exists(filePath))
                    {
                        string existingJson = File.ReadAllText(filePath);
                        existingNotes = JsonConvert.DeserializeObject<List<Note>>(existingJson);
                    }


                    notes = NoteTakingGeneralOperation.CreateNote(userid, NoteContent);

                    existingNotes.Add(notes);

                    string jsonString = JsonConvert.SerializeObject(existingNotes, Formatting.Indented);
                    File.WriteAllText(filePath, jsonString);

                }

                else
                {
                    return;
                }
                break;

        }

    }
}