using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace Dances_Words_Algorithm
{
    class MatrixMaker
    {
        private BL bl;
        private DataTable finalDt;
        private DataTable wordsDt;
        private DataTable featuresDt;
        private DataTable matrix;
        private ProgressBar pBar;
        private Label lbl;
        DataTable dictionaryDt;

        public MatrixMaker(ProgressBar pBar, Label lbl)
        {
            this.lbl = lbl;
            bl = new BL();
            finalDt = new DataTable();
            this.pBar = pBar;
        }// Constructor

        public void PopulateMatrixTables(Label lbl)
        {
            pBar.Value = 0;
            pBar.Maximum = 3;

            dictionaryDt = bl.GetDictionary();
            int counter = 0;

            /* Populate Words DataTale */
            wordsDt = new DataTable("Words");
            wordsDt.Columns.Add("SongId", typeof(string));
            PopulateDataTable(ref wordsDt, dictionaryDt, lbl, ref counter);
            pBar.Value++;

            /* Populate Features DataTable */
            featuresDt = new DataTable("Features");
            featuresDt.Columns.Add("SongId", typeof(string));
            PopulateDataTable(ref featuresDt, bl.GetAllChoreographers(), lbl, ref counter);
            PopulateDataTable(ref featuresDt, bl.GetAllComposers(), lbl, ref counter);
            PopulateDataTable(ref featuresDt, bl.GetAllSingers(), lbl, ref counter);
            PopulateDataTable(ref featuresDt, bl.GetAllWriters(), lbl, ref counter);
            PopulateDataTable(ref featuresDt, bl.GetAllYears(), lbl, ref counter);
            pBar.Value += 2;

        }// Populate Matrix Tables

        private void PopulateDataTable(ref DataTable dtToPopulate, DataTable dtPopulating, Label lbl, ref int counter)
        {
            try
            {
                foreach (DataRow row in dtPopulating.Rows)
                {
                    if (row[1].ToString().Length > 1)
                    {
                        DataColumn dc = dtToPopulate.Columns.Add(row[1].ToString().Trim(), typeof(string));
                    }// If
                }// Foreach
            }// Try
            catch (Exception)
            {
                counter++;
                lbl.Text = Convert.ToString(counter);
            }// Catch
        }// Populate Datatable

        public void populateMatrix()
        {
            pBar.Value = 0;
            int counter = 0;
            DataTable songs = bl.GetAllTrainingSet();
            pBar.Maximum = songs.Rows.Count * wordsDt.Columns.Count;
            //PopulateWordsMatrix(songs, pBar, counter);
            PopulateFeaturesMatrix(songs, pBar);

            /* Calculate Features */
            

        }// Populate Matrix

        private void PopulateWordsMatrix(DataTable songs, ProgressBar pBar, int counter)
        {
            foreach (DataRow song in songs.Rows)
            {
                int songId = Convert.ToInt32(song[0].ToString());
                DataRow newRow = wordsDt.NewRow();
                newRow[0] = Convert.ToString(songId);

                /* Calculate TF-IDF for each term in each document (Words Data Table) */
                lbl.Text = "Words";
                foreach (DataColumn column in wordsDt.Columns)
                {
                    string term = column.Caption;
                    string termFreq = "";
                    string docFreq = "";
                    double tfIdf = 0;
                    if (term != "SongId" && term != "" && term.Length > 1)
                    {
                        bool isEnglish = Regex.IsMatch(term, "^[a-zA-Z0-9]*$");

                        if (isEnglish == false)
                        {
                            if (term.Contains("…") || term.Contains("[") || term.Contains("*") || term.Contains("¿"))
                            {
                                string newTerm = term;
                                term = newTerm.Replace("…", "").Replace("[", "").Replace("]", "").Replace("*", "").Replace("¿", "");
                            }
                            if (term != "")
                            {
                                DataTable dt = bl.GetDictionaryTermByTerm(term.Trim());
                                if (dt.Rows.Count > 0)
                                {
                                    DataRow dictionaryTerm = dt.Rows[0];

                                    if (dictionaryTerm[1].ToString().Trim() == term.Trim())
                                    {
                                        string[] freqDetail = dictionaryTerm[2].ToString().Split('*');
                                        for (int j = 0; j < freqDetail.Length; j++)
                                        {
                                            if (freqDetail[j].Trim() == Convert.ToString(songId).Trim())
                                            {
                                                termFreq = freqDetail[j + 1];
                                                docFreq = Convert.ToString(freqDetail.Length / 2);
                                                if (termFreq != "" && docFreq != "")
                                                {
                                                    double tf = 1 + Math.Log10(Convert.ToInt32(termFreq));
                                                    double idf = Math.Log10((songs.Rows.Count / Convert.ToInt32(docFreq)));
                                                    tfIdf = tf * idf;
                                                    if (tfIdf < 0)
                                                        tfIdf = 0;
                                                    break;
                                                }// If
                                                j++;
                                            }// If
                                        }// For - Doc+Freq pair
                                    }// If
                                }// If
                            }// If
                        }// If
                        pBar.Value++;
                        newRow[column.Caption] = Convert.ToString(tfIdf);
                    }// If

                }// Foreach - Column (Word) in matrix
                object[] array = newRow.ItemArray;
                wordsDt.Rows.Add(array);

                pBar.Value++;
            }// Foreach - SongId
            WriteMatrixToCSV(wordsDt);
            wordsDt.Clear();
        }// Populate Words Matrix

        private void PopulateFeaturesMatrix(DataTable songs, ProgressBar pBar)
        {
            pBar.Value = 0;
            pBar.Maximum = songs.Rows.Count;
            lbl.Text = "Features";
            foreach (DataRow song in songs.Rows)
            {
                DataRow newRow = featuresDt.NewRow();
                foreach (DataColumn column in featuresDt.Columns)
                {
                    string feature = column.Caption;
                    if (feature == "SongId")
                        newRow["SongId"] = song[0].ToString();
                    for (int i = 2; i < 6; i++)
                    {
                        string rowVal = "";
                        if (song[i].ToString().Trim() == feature.Trim())
                            rowVal = "1";
                        else
                            rowVal = "0";
                        newRow[column.Caption] = rowVal;
                    }// For

                }// Foreach - Column (Features)
                object[] array = newRow.ItemArray;
                featuresDt.Rows.Add(array);
                pBar.Value++;
            }// Foreach - Song
            WriteMatrixToCSV(featuresDt);
        }// Populate Features Matrix

        private void WriteMatrixToCSV(DataTable dt)
        {
            StringBuilder sb = new StringBuilder();

            //string[] columnNames = dt.Columns.Cast<DataColumn>().
            //                                  Select(column => column.ColumnName).
            //                                  ToArray();
            //sb.AppendLine(string.Join(",", columnNames));

            for (int i = 0; i < dt.Columns.Count; i++)
            {
                sb.Append(dt.Columns[i].Caption + ",");
            }// For - Columns
            sb.Remove(sb.Length - 1, 1);
            sb.Append("\n");
            foreach (DataRow row in dt.Rows)
            {
                string[] fields = row.ItemArray.Select(field => field.ToString()).
                                                ToArray();
                sb.AppendLine(string.Join(",", fields));
            }

            using (StreamWriter sw = new StreamWriter(dt.TableName + ".csv", true, Encoding.UTF8))
            {
                sw.WriteLine(sb.ToString());
            }



            //File.WriteAllText(dt.TableName+".csv", sb.ToString());
        }// Write Matrix To CSV
        
    }// Class
}// Namespace
