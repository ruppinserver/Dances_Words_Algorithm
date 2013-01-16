using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;

/// <summary>
/// Summary description for BL
/// </summary>
public class BL
{
    DAL dl;

    public BL()
    {
        dl = new DAL();
    }// Constructor

    public void AddSong(string songId, string songName, string composer, string poet, int year, string choreograph, string lyrics, string singer, out int ans)
    {
        ans = 0;
        if (songName != null && lyrics != null)
        {
            if (songName.Trim() != "" || lyrics.Trim() != "")
            {
                string parameters = string.Format("@SongId,{0},@SongName,{1},@Composer,{2},@Poet, {3},@DanceYear,{4},@Choreograph,{5},@Singer,{6},@Lyrics,{7}", songId, songName, composer, poet, year, choreograph, singer, lyrics);
                dl.runStoreProcedureWithVariables("proc_Insert_Songs", parameters, out ans);
            }// If
        }// If


    }// Add Song

    public DataTable getAllSongs()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Songs"));
        return dt;
    }// Get All Songs

    public void AddToTestTable(string songId, string songName, string composer, string poet, int year, string choreograph, string lyrics, string singer, out int ans)
    {
        ans = 0;
        if (songName != null && lyrics != null)
        {
            if (songName.Trim() != "" || lyrics.Trim() != "")
            {
                string parameters = string.Format("@SongId,{0},@SongName,{1},@Composer,{2},@Poet, {3},@DanceYear,{4},@Choreograph,{5},@Singer,{6},@Lyrics,{6}", songId, songName, composer, poet, year, choreograph, singer, lyrics);
                dl.runStoreProcedureWithVariables("proc_Insert_Into_Test_Set", parameters, out ans);
            }// If
        }// If


    }// Add To Test Table

    public void AddToTrainTable(string songId, string songName, string composer, string poet, int year, string choreograph, string lyrics, string singer, out int ans)
    {
        ans = 0;
        if (songName != null && lyrics != null)
        {
            if (songName.Trim() != "" || lyrics.Trim() != "")
            {
                string parameters = string.Format("@SongId,{0},@SongName,{1},@Composer,{2},@Poet, {3},@DanceYear,{4},@Choreograph,{5},@Singer,{6},@Lyrics,{6}", songId, songName, composer, poet, year, choreograph, singer, lyrics);
                dl.runStoreProcedureWithVariables("proc_Insert_Into_Training_Set", parameters, out ans);
            }// If
        }// If


    }// Add To Training Set

    public DataTable GetAllTrainingSet()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Training_Set"));
        return dt;
    }// Get All Training Set

    public void AddTermToDictionary(string term, string frequency, out int ans)
    {
        ans = 0;
        string parameters = string.Format("@Term,{0},@Frequency,{1}", term, frequency);
        dl.runStoreProcedureWithVariables("proc_Insert_Term_To_Dictionary", parameters, out ans);
    }// Add To Dictionary

    public void AddToWordsTables(string word, string docId)
    {
        int ans;
        string parameters = string.Format("@Word,{0},@DocId,{1}", word, docId);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Words", parameters, out ans);
    }// Add To Words Tables

    public DataTable GetAllWords_1()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Words_1"));
        return dt;
    }// Get All Words_1

    public void AddToPreliminaryTerms(string term, string docs)
    {
        int ans;
        string parameters = string.Format("@Term,{0},@Docs,{1}", term, docs);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_PerliminaryTerms", parameters, out ans);
    }// Add To Preliminary Terms

    public DataTable GetAllPreliminaryTerms()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM PreliminaryTerms"));
        return dt;
    }// Get All Perliminary Terms

    public void AddToChoreographers(string choreographer)
    {
        int ans;
        string parameters = string.Format("@Choreographer,{0}", choreographer);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Choreographers", parameters, out ans);
    }// Add To Choreographers

    public void AddToComposers(string composer)
    {
        int ans;
        string parameters = string.Format("@Composer,{0}", composer);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Composers", parameters, out ans);
    }// Add To Composers

    public void AddToSingers(string singer)
    {
        int ans;
        string parameters = string.Format("@Singer,{0}", singer);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Singers", parameters, out ans);
    }// Add To Singers

    public void AddToWriters(string writer)
    {
        int ans;
        string parameters = string.Format("@Writer,{0}", writer);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Writers", parameters, out ans);
    }// Add To Writers

    public void AddToYears(string year)
    {
        int ans;
        string parameters = string.Format("@Year,{0}", year);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Years", parameters, out ans);
    }// Add To Years

    public void AddToFeatures(string feature)
    {
        int ans;
        string parameters = string.Format("@Feature,{0}", feature);
        dl.runStoreProcedureWithVariables("proc_Insert_Into_Features", parameters, out ans);
    }// Add To Features

    public DataTable GetDictionary()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Dictionary"));
        return dt;
    }// Get Dictionary

    public DataTable GetAllChoreographers()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Choreographers"));
        return dt;
    }// Get Choreographers

    public DataTable GetAllComposers()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Composer"));
        return dt;
    }// Get Composer

    public DataTable GetAllSingers()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Singers"));
        return dt;
    }// Get Singers

    public DataTable GetAllWriters()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Writer"));
        return dt;
    }// Get Writer

    public DataTable GetAllYears()
    {
        DataTable dt = dl.retrieveTableData(string.Format("SELECT * FROM Years"));
        return dt;
    }// Get Years

    public DataTable GetDictionaryTermByTerm(string term)
    {
        DataTable dt = dl.retrieveTableData(string.Format("EXEC proc_Get_term_Details_by_Term {0}", term.Replace("'", "")));
        return dt;
    }// Get Term By Term (matching)

    public void BuildSqlTable(DataTable dt, string tableName)
    {
        StringBuilder query = new StringBuilder();
        query.Append("CREATE TABLE ");
        query.Append(tableName);
        query.Append(" ( ");

        for (int i = 0; i < dt.Columns.Count; i++)
        {
            query.Append(string.Format("filed{0}", i));
            query.Append(" ");
            query.Append("nvarchar(250)");
            query.Append(", ");
        }

        if (dt.Columns.Count > 1) { query.Length -= 2; }  //Remove trailing ", "
        query.Append(")");
        dl.SqlCommands(query.ToString());

    }// Build SQL Table
}// Class