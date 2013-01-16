using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;

/// <summary>
/// Summary description for Dictionary
/// </summary>
public class Dictionary
{
    BL bl;
    public Dictionary(int cue, ProgressBar pBar)
    {
        bl = new BL();
        DataTable dt = bl.GetAllTrainingSet();

        switch (cue)
        {
            case 1:
                // Get All Words
                PopulateWordsTables(dt, pBar);
                break;
            case 2:
                // Preliminary Terms
                //DataTable
                //GetTerms(
                GetTermFrequencyData(pBar);
                break;
            case 3:
                // Create Dictionary
                CreateDictionary(pBar);
                break;
            case 4:
                // Create Features Sets
                HandleExtraInfo(pBar);
                break;
        }// Switch
    }// Constructor

    private void PopulateWordsTables(DataTable dt, ProgressBar pBar)
    {
        pBar.Maximum = dt.Rows.Count;
        pBar.Value = 0;
        foreach (DataRow row in dt.Rows)
        {
            string[] words = row[7].ToString().Split(' ');
            for (int i = 0; i < words.Length; i++)
            {
                bl.AddToWordsTables(words[i], row[0].ToString());
            }// For

            pBar.Value++;
        }// Foreach
    }// Populate Words tables

    private void GetTermFrequencyData(ProgressBar pBar)
    {
        DataTable words1 = bl.GetAllWords_1();
        DataTable words2 = bl.GetAllWords_1();
        pBar.Value = 0;
        pBar.Maximum = words1.Rows.Count;

        foreach (DataRow row1 in words1.Rows)
        {
            string term = SymbolRemover(row1[1].ToString());
            if (term != "")
            {
                string termFreq = "";
                for (int i = 0; i < words2.Rows.Count; i++)
                {
                    DataRow row2 = words2.Rows[i];
                    string word = SymbolRemover(row2[1].ToString());
                    if (word != "")
                    {
                        if (word.Trim() == term.Trim())
                        {
                            termFreq += row2[2].ToString() + "*";
                            words2.Rows.Remove(row2);
                        }// If Match
                    }// If (Word Not Empty!)
                }// For - Words_2
                if (termFreq != "")
                {
                    bl.AddToPreliminaryTerms(term, termFreq);
                }// If
            }// If (Term Not Empty!)
            pBar.Value++;
        }// Foreach - Words_1
    }// Get Term Frequency Data

    private void GetTerms(DataTable dt, ProgressBar pBar)
    {
        pBar.Maximum = dt.Rows.Count;

        foreach (DataRow row in dt.Rows)
        {
            // Get Word to serach data
            string[] words = row[7].ToString().Split(' ');
            for (int w = 0; w < words.Length; w++)
            {
                if (words[w] != "")
                {
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow songRow = dt.Rows[i];
                        string[] songLyrics = songRow[7].ToString().Split(' ');

                        for (int j = 0; j < songLyrics.Length; j++)
                        {
                            if (songLyrics[j] != "")
                            {
                                if (songLyrics[j] == words[w])
                                {
                                    int ansInsertTermToDictionary = 0;
                                    string frequency = songRow[0].ToString() + "*" + 1 + "*";
                                    bl.AddTermToDictionary(words[w], frequency, out ansInsertTermToDictionary);
                                    if (ansInsertTermToDictionary == 1)
                                    {
                                        //Added = True
                                    }// If - Added
                                    else
                                    {
                                        // Not Added
                                    }// Else - Not Added
                                }// If Word Found
                            }// If SongLyric not empty!
                        }// For - Word in Song
                    }// For - Songs Rows
                }// For each word
            }// If Word not empty!
            pBar.Value++;
        }// Foreach Word in Row
    }// Get Terms

    private string SymbolRemover(string text)
    {
        string tmpText = text.Replace("/", "").Replace("?", "").Replace(".", "").Replace(",", "").Replace("'", "").Replace("\"", "").Replace("!", "").Replace(")", "").Replace("(", "").Replace("-", "").Replace("_", "").Replace(":", "").Replace("´", "").Replace("...", "").Replace(";", "").Replace("…", "").Replace("[", "").Replace("]", "").Replace("*", "").Replace("¿", "").Trim();
        string newText = tmpText.Replace("1", "").Replace("2", "").Replace("3", "").Replace("4", "").Replace("5", "").Replace("6", "").Replace("7", "").Replace("8", "").Replace("9", "").Replace("0", "").Trim();
        return newText;
    }// Symbol Remover

    public void CreateDictionary(ProgressBar pBar)
    {
        DataTable dt = bl.GetAllPreliminaryTerms();
        pBar.Value = 0;
        pBar.Maximum = dt.Rows.Count;
        foreach (DataRow row in dt.Rows)
        {
            string[] docs = row[2].ToString().Split('*');
            string dictionaryFreq = "";
            for (int i = 0; i < docs.Length; i++)
            {
                string doc = docs[i].Trim();
                int docCounter = 0;

                for (int j = 0; j < docs.Length; j++)
                {
                    if (doc == docs[j].Trim())
                    {
                        docCounter++;
                        docs[j] = "";
                    }// If
                }// For
                if (doc != "")
                    dictionaryFreq += doc + "*" + docCounter + "*";
            }// For
            int ansInsertToDictionary;
            bl.AddTermToDictionary(row[1].ToString().Trim(), dictionaryFreq, out ansInsertToDictionary);
            pBar.Value++;
        }// Foreach Word
    }// Create Dictionary

    public void HandleExtraInfo(ProgressBar pBar)
    {
        DataTable dt = bl.getAllSongs();
        pBar.Value = 0;
        pBar.Maximum = dt.Rows.Count;
        foreach (DataRow row in dt.Rows)
        {
            if (row[5].ToString().Contains("+") == true)
            {
                string[] choreographers = row[5].ToString().Split('+');
                for (int i = 0; i < choreographers.Length; i++)
                {
                    if (choreographers[i] != "")
                    {
                        bl.AddToChoreographers(choreographers[i].Trim());
                        bl.AddToFeatures(choreographers[i].Trim());
                    }// If
                }// For

            }// If (Contains +)
            else
            {
                if (row[5].ToString() != "")
                {
                    bl.AddToChoreographers(row[5].ToString());
                    bl.AddToFeatures(row[5].ToString());
                }// If
            }// Else

            if (row[2].ToString() != "")
            {
                bl.AddToComposers(row[2].ToString());
                bl.AddToFeatures(row[2].ToString());
            }// If

            if (row[6].ToString() != "")
            {
                bl.AddToSingers(row[6].ToString());
                bl.AddToFeatures(row[6].ToString());
            }// If

            if (row[3].ToString() != "")
            {
                bl.AddToWriters(row[3].ToString());
                bl.AddToFeatures(row[3].ToString());
            }// If

            if (row[4].ToString() != "")
            {
                bl.AddToYears(row[4].ToString());
                bl.AddToFeatures(row[4].ToString());
            }// If

            pBar.Value++;
        }// Foreach
    }// Handle Extra Info
}// Class