using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Dances_Words_Algorithm
{
    public partial class frmMain : Form
    {
        MatrixMaker matrix;

        public frmMain()
        {
            InitializeComponent();
        }// FrmMain

        private void cmdStart_Click(object sender, EventArgs e)
        {
            WorkFlowManager();
        }// Start by button

        private void WorkFlowManager()
        {
            matrix = new MatrixMaker(progressBar, lblTemp);
            ////Phase1();
            //Phase2();
            //phase3();
            //Phase4();
            //Phase5();
            //Phase6();
            Phase7();
            Phase8();
        }// Work Flow Manager

        private void Phase1()
        {
            progressBar.Visible = true;
            lblPhase1.Enabled = true;
            Data_Integrator integrator = new Data_Integrator();
            integrator.readFile(Application.StartupPath + "\\Data1.txt", Application.StartupPath, progressBar);
            lblPhase1.Text += "   |DONE|";
            lblPhase1.Enabled = false;
        }// Phase-1

        private void Phase2()
        {
            lblPhase2.Enabled = true;
            Randomizer rnd = new Randomizer(progressBar);
            lblPhase2.Text += "   |DONE|";
            lblPhase2.Enabled = false;
        }// Phase-2

        private void phase3()
        {
            lblPhase3.Enabled = true;
            Dictionary dic = new Dictionary(1, progressBar);
            lblPhase3.Text += "   |DONE|";
            lblPhase3.Enabled = false;
        }// Phase-3

        private void Phase4()
        {
            lblPhase4.Enabled = true;
            Dictionary dic = new Dictionary(2, progressBar);
            lblPhase4.Text += "   |DONE|";
            lblPhase4.Enabled = false;
        }// Phase-4

        private void Phase5()
        {
            lblPhase5.Enabled = true;
            Dictionary dic = new Dictionary(3, progressBar);
            lblPhase5.Text += "   |DONE|";
            lblPhase5.Enabled = false;
        }// Phase-5

        private void Phase6()
        {
            lblPhase6.Enabled = true;
            Dictionary dic = new Dictionary(4, progressBar);
            lblPhase6.Text += "   |DONE|";
            lblPhase6.Enabled = false;
        }// Phase-6

        private void Phase7()
        {
            lblPhase7.Enabled = true;
            matrix.PopulateMatrixTables(lblError);
            lblPhase7.Text += "   |DONE|";
            lblPhase7.Enabled = false;
        }// Phase-7


        private void Phase8()
        {
            lblPhase8.Enabled = true;
            matrix.populateMatrix();
            lblPhase8.Text += "   |DONE|";
            lblPhase8.Enabled = false;
        }// Phase-8

        private void Phase9()
        {
            lblPhase8.Enabled = true;
            matrix.populateMatrix();
            lblPhase8.Text += "   |DONE|";
            lblPhase8.Enabled = false;
        }// Phase-9

        private void Phase10()
        {
            lblPhase8.Enabled = true;
//Omri Merging Test
        }// Phase-10
    }// Class
}// Namespace
