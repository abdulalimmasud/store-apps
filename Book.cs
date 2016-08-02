using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Books
{
    public class Book : INotifyPropertyChanged
    {
        private int bookNo;

        public int BookNo
        {
            get { return this.bookNo; }
            set { this.bookNo = value; this.OnPropertyChanged("BookNo"); }
        }
        private string bookName;

        public string BookName
        {
            get { return this.bookName; }
            set { this.bookName = value; this.OnPropertyChanged("BookName"); }
        }
        private string author;

        public string Author
        {
            get { return this.author; }
            set { this.author = value; this.OnPropertyChanged("Author"); }
        }
        private decimal year;

        public decimal Year
        {
            get { return this.year; }
            set { this.year = value; this.OnPropertyChanged("Year"); }
        }
        private string quote1;

        public string Quote1
        {
            get { return this.quote1; }
            set { this.quote1 = value; this.OnPropertyChanged("Quote1"); }
        }
        private string quote2;

        public string Quote2
        {
            get { return this.quote2; }
            set { this.quote2 = value; this.OnPropertyChanged("Quote2"); }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
