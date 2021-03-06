﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FilmLib_C_sharp_
{
    public partial class Search : Form
    {
        private User usr_;
        private Dashboard frm4_;
        
        public Search(ref List<Film> matched, ref User usr, Dashboard frm4)          //prepare the listView with matched movies
        {
            InitializeComponent();
            usr_ = usr;
            frm4_ = frm4;
            for(int i = 0; i < matched.Count; i++)
            {
                //MessageBox.Show(matched[i].ToString());
                ListViewItem temp = new ListViewItem(matched[i].ToString());
                temp.SubItems.Add(matched[i].getGenre());
                temp.SubItems.Add(matched[i].getRate().ToString());
                results.Items.Add(temp);
               
            }
        }

        private void detailsBtn_Click(object sender, EventArgs e)
        {
            if (results.SelectedItems.Count > 1)
            {
                MessageBox.Show("Cannot select more than one movie");
            }
            else if (results.SelectedItems.Count == 0)
            {
                MessageBox.Show("Select a movie");        
            }
            else
            {
                FilmDetail frm6 = new FilmDetail(results.SelectedItems[0].Text, ref usr_, frm4_);
                frm6.Show();
                frm4_.Closed += (s, args) => frm6.Close();                  //when users sign out, close the movie info page 
            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
