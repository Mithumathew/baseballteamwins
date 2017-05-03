using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace prac_10
{
    class VM : INotifyPropertyChanged
    {
        private List<string> teamlist;
        public List<string> Teamlist
        {
            get { return teamlist; }
            set { teamlist = value;  OnPropertyChanged(); }

        }
        private string winner;
        public string Winner
        {
            get { return winner; }
            set { winner = value;  OnPropertyChanged(); }
        }
        //reading the file to listbox
        public void Filereader()
        {
            teamlist = new List<string>();
            StreamReader sr1 = new StreamReader("Teams.txt");
            while(sr1.Peek()!= -1)
            { teamlist.Add(sr1.ReadLine()); }
        }
        //Method to count the number of times the team won
        public void Winnumber( string teamname)
        { 
            List<string> winnerlist = new List<string>();
            StreamReader sr2 = new StreamReader("WorldSeriesWinners.txt");
            int index = 0;
            int wincount = 0;

            while (sr2.Peek() != -1)
            {
                winnerlist.Add(sr2.ReadLine().ToString());
            }
            winnerlist.Sort();

            while (index >= 0)
            {
                index = winnerlist.BinarySearch(teamname);
                    if(index >= 0)
                {
                    wincount++;
                    winnerlist.RemoveAt(index);
                  }
            }
            Winner = wincount.ToString();
            winnerlist.Clear();

        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string caller = null)
        {
            // make sure only to call this if the value actually changes

            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(caller));
            }
        }
    }
}
