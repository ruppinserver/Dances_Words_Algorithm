using System;
using System.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

/// <summary>
/// Summary description for Randomizer
/// </summary>
public class Randomizer
{
    BL bl;
    public Randomizer(ProgressBar pBar)
    {
        bl = new BL();
        pBar.Value = 0;

        DataTable dt = bl.getAllSongs();

        int numOfRows = dt.Rows.Count;
        int numForTraining = Convert.ToInt32(Math.Round(numOfRows * 0.6));
        int numForTest = Convert.ToInt32(Math.Round(numOfRows * 0.4));
        DataRow dr = dt.Rows[50];
        DevideSets(dt, numForTest, numForTraining, pBar);

    }// Constructor

    private void DevideSets(DataTable data, int testNum, int trainSet, ProgressBar pBar)
    {
        DataTable dtTest = new DataTable();
        DataTable dtTrain = new DataTable();
        pBar.Maximum = data.Rows.Count;
        int ansInsertTest = 0, ansInsertTrain = 0, insertedTest = 0, insertedTrain = 0, excludedTest = 0, excludedTrain = 0;
        int trainCounter = 0, testCounter = 4;
        foreach (DataRow row in data.Rows)
        {

            if (trainCounter < 2)
            {
                bl.AddToTestTable(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4].ToString()), row[5].ToString(), row[6].ToString(), row[7].ToString(), out ansInsertTrain);
                if (ansInsertTrain == 1)
                    insertedTrain++;
                else
                    excludedTrain++;

                trainCounter++;

                if (trainCounter == 2)
                    testCounter = 0;
            }// If
            else
            {
                if (testCounter <= 3)
                {
                    bl.AddToTrainTable(row[0].ToString(), row[1].ToString(), row[2].ToString(), row[3].ToString(), Convert.ToInt32(row[4].ToString()), row[5].ToString(), row[6].ToString(), row[7].ToString(), out ansInsertTest);
                    if (ansInsertTest == 1)
                        insertedTest++;
                    else
                        excludedTest++;

                    testCounter++;

                    if (testCounter == 3)
                        trainCounter = 0;
                }// If
            }// Else
            pBar.Value++;
        }// Foreach
    }// Devide Sets

}// Class