using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Windows.Forms;
using System.Threading;


public class Data_Integrator
{
    string server;
    BL bl;
    string[] currentRecord = new string[8];
    int tmpSongId;
    List<string[]> outputList = new List<string[]>();
    
    public Data_Integrator()
    {
        bl = new BL();
    }// Constructor

    public void readFile(string filePath, string serverPath, ProgressBar pBar)
    {
        int tmpSongNum = 0;
        server = serverPath;
        string line;
        int counter = 0;

        StreamReader sr = new StreamReader(filePath, System.Text.ASCIIEncoding.Default);
        pBar.Maximum = 1591;

        while ((line = sr.ReadLine()) != null)
        {
            bool isNew = false;
            string[] lineArray = line.Split(',');

            if (counter == 0)
            {
                tmpSongNum = Convert.ToInt32(lineArray[0]);
            }// If
            else if (tmpSongNum != Convert.ToInt32(lineArray[0]))
            {
                tmpSongNum = Convert.ToInt32(lineArray[0]);
                counter = 0;
                isNew = true;
            }// Else If

            LineBreaker(lineArray, isNew, pBar);
            counter++;
        }// While
        sr.Close();
    }/// Read File

    private void LineBreaker(string[] line, bool isNew, ProgressBar pBar)
    {
        if (isNew == true && currentRecord[7] != "")
        {
            if (currentRecord[4] == "")
                currentRecord[4] = "0";
            int ansAddSong = 0;
            bl.AddSong(currentRecord[0], currentRecord[1], currentRecord[2], currentRecord[3], Convert.ToInt32(currentRecord[4]), currentRecord[5], currentRecord[7], currentRecord[6], out ansAddSong);
            if (ansAddSong == 1)
            {
                currentRecord = new string[8];
                if (pBar.Value < pBar.Maximum)
                    pBar.Value += 1;
            }// If
            //else
            //MessageBox.Show("Error Adding Song!!");
        }// If - New Record!

        currentRecord[0] = line[0].Trim();
        currentRecord[1] = line[1].Trim();

        if (line.Length > 2 && line.Length < 5)
        {
            string str = line[3].Replace("\"", " ").Trim();
            int fieldType = int.Parse(str);
            switch (fieldType)
            {
                case 146:
                    // Composer
                    currentRecord[2] = line[2].Replace("\"", " ").Trim();
                    break;
                case 180:
                    // Writer
                    currentRecord[3] = line[2].Replace("\"", " ").Trim();
                    break;
                case 145:
                    // Year
                    currentRecord[4] = line[2].Replace("\"", " ").Trim();
                    break;
                case 144:
                    // Choreographer
                    currentRecord[5] = line[2].Replace("\"", " ").Trim();
                    break;
                case 147:
                    // Singer
                    currentRecord[6] = line[2].Replace("\"", " ").Trim();
                    break;
                default:
                    if (currentRecord[1] != null)
                        currentRecord[7] = LyricsFinder(currentRecord[1].Trim());
                    break;
            }// Switch        

            // Check if record is full
            //for (int i = 0; i < currentRecord.Length; i++)
            //{
            //    if (i != 2)
            //    {
            //        if (currentRecord[i] == "" || currentRecord[i] == null)
            //            isReadyToInsert = false;
            //    }// If
            //}// For
        }// IF
    }// Line Breaker
    
    private string LyricsFinder(string name)
    {
        string lyrics = "";
        if (name != null)
        {
            DirectoryInfo dir = new DirectoryInfo(server + "\\TXT");
            foreach (FileInfo file in dir.GetFiles())
            {
                string[] tmpArray = file.Name.Split('.');
                string[] devidersArray = tmpArray[0].Split('-');
                string songName = devidersArray[0].Trim();

                devidersArray = name.Split('-');
                name = devidersArray[0].Trim();

                if (name == songName)
                {
                    lyrics = File.ReadAllText(file.FullName);
                    break;
                }
            }// Foreach Sub-Directory

        }// If - Name not null
        return lyrics;
    }// Lyrics Finder


}// Class