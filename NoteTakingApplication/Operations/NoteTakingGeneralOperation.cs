using System;
using NoteTakingApplication.Data;
using NoteTakingApplication.Views;
using NoteTakingApplication.OutputTexts;
using NoteTakingApplication.Operations;
using System.Text;

namespace NoteTakingApplication.Operations;

public static class NoteTakingGeneralOperation
{
    private static CreateNewUser CreateNewUser = null;
    private static NoteContents NoteContents = null;
    private static UsersContent UsersContent = null;
    private static CreateNewNote CreateNewNote = null;
    

    public static User CreateUser(string username)
    {

        return new User(username);
    }

    public static CreateNewUser CreateUserView(Users users)
    {
        if (CreateNewUser == null)
        {
            CreateNewUser = new CreateNewUser(users);
        }
        return CreateNewUser;
    }

    public static Log LogToHistory(int userid, string Action)
    {
        return new Log(userid, Action);
    }

    public static Note CreateNote(int userid, string noteContent)
    {
        return new Note(userid, noteContent);
    }

    public static CreateNewNote CreateNewNoteView(Note notes)
    {
        if (CreateNewNote == null)
        {
            CreateNewNote = new CreateNewNote(notes);
            
        }
        return CreateNewNote;
    }
    
    public static NoteContents GetNoteContents(Note notes)
    {
        return new NoteContents();
    }

    public static NoteContents NoteContentsView(Note notes)
    {
        if (NoteContents == null)
        {
            NoteContents = new NoteContents();
        }
        return NoteContents;
    }

    public static UsersContent GetUsersContent()
    {
        return new UsersContent();
    }

    public static UsersContent GetUsersContentView()
    {
        if (UsersContent == null)
        {
            UsersContent = new UsersContent();
        }
        return UsersContent;
    }

}