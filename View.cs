using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace Books
{
    public class View : INotifyPropertyChanged
    {
        private List<Book> books;
        private int currentBook;
        public Command NextBook { get; private set; }
        public Command PreviousBook { get; private set; }
        public View()
        {
            this.currentBook = 0;
            this.IsAtStrart = true;
            this.IsAtEnd = false;
            this.NextBook = new Command(this.Next, () => { return this.books.Count > 0 && !this.IsAtEnd; });
            this.PreviousBook = new Command(this.Previous, () => { return this.books.Count > 0 && !this.IsAtStrart; });
            this.books=new List<Book>
            {
                new Book
                {
                    BookNo=1,
                    BookName="In Search of Lost Time",
                    Author="Marcel Proust",
                    Year=1913,
                    Quote1="1. The Universe is true for us all and dissimilar to each of us.",
                    Quote2="2. Love is a striking example of how little reality means to us."
                },
                new Book
                {
                    BookNo=2,
                    BookName="Ulysses",
                    Author="James Joyce",
                    Year=1904,
                    Quote1="1. God made food, the devil the cooks.",
                    Quote2="2. To learn one must be humle, but life is the great teacher."
                },
                new Book
                {
                    BookNo=3,
                    BookName="Moby Dick",
                    Author="Herman Melville",
                    Year=1851,
                    Quote1="1. It is not down on any map, true places never are.",
                    Quote2="2. I try all things, I achieve what I can."
                },
                new Book
                {
                    BookNo=4,
                    BookName="Hamlet",
                    Author="William Shakespeare",
                    Year=1599,
                    Quote1="1. There is nothing either good or bad, but thinking makes it so.",
                    Quote2="2. If you are true ourselves, we can not be false to anyone."
                },
                new Book
                {
                    BookNo=5,
                    BookName="Alice's Adventures in Wonderland",
                    Author="Lewo Carroll",
                    Year=1862,
                    Quote1="1. Who in the world am I? Ah, that's the great puzzle.",
                    Quote2="2. Evereything is funny, if you can laugh at it."
                },
                new Book
                {
                    BookNo=6,
                    BookName="The Catcher in the Rye",
                    Author="J. D. Salinger",
                    Year=1945,
                    Quote1="1. Nobody’d move. . . . Nobody’d be different.\n   The only thing that would be different would be you.",
                    Quote2="2. People always think something's all true."
                },
                new Book
                {
                    BookNo=7,
                    BookName="Absalom, Absalom!",
                    Author="William Faulkner",
                    Year=1936,
                    Quote1="1. If happy I can be I will, if suffer I must I can.",
                    Quote2="2. It takes an awful lot of character to quit anything when you are losing."
                },
                new Book
                {
                    BookNo=8,
                    BookName="Middlemarch",
                    Author="George Eliot",
                    Year=1869,
                    Quote1="1. It is a narrow mind which cannot look at a subject from various points of view.",
                    Quote2="2. People are almost always better than their neighbors think they are."
                },
                new Book
                {
                    BookNo=9,
                    BookName="The Trial",
                    Author="Franz Kafka",
                    Year=1914,
                    Quote1="1. Logic may indeed be unshakeable,\n   but it cannot withstand a man who is determined to live.",
                    Quote2="2. It's only because of their stupidity that they're able to be so sure of themselves."
                },
                new Book
                {
                    BookNo=10,
                    BookName="The Red and the Black",
                    Author="Stendhal",
                    Year=1830,
                    Quote1="1. A good book is an event in my life.",
                    Quote2="2. After moral poisoning, one requires physical remedies and a bottle of champagne."
                },
                new Book
                {
                    BookNo=11,
                    BookName="The Stranger",
                    Author="Albert Camus",
                    Year=1946,
                    Quote1="1. I opened myself to the gentle indifference of the world.",
                    Quote2="2. Since we're all going to die, it's obvious that when and how don't matter."
                },
                new Book
                {
                    BookNo=12,
                    BookName="Beloved",
                    Author="Toni Morrison",
                    Year=1987,
                    Quote1="1. Definitions belong to the definers, not the defined.",
                    Quote2="2. Today is always here, Tomorrow, never."
                },
                new Book
                {
                    BookNo=13,
                    BookName="Collected Fiction",
                    Author="Jorge Luis Borges",
                    Year=1935,
                    Quote1="1. I have no way of knowing whether the events that I am about to narrate \n   are effects or causes.",
                    Quote2="2. Time forks perpetually toward innumerable futures.\n   In one of them I am your enemy."
                },
                new Book
                {
                    BookNo=14,
                    BookName="Leaves of Grass",
                    Author="Walt Whitman",
                    Year=1855,
                    Quote1="1. Resist much, obey little.",
                    Quote2="2. I am larger, better than I thought; I did not know I held so much goodness."
                },
                new Book
                {
                    BookNo=15,
                    BookName="Candide",
                    Author="Voltaire",
                    Year=1759,
                    Quote1="1. If this is the best of possible worlds, what then are the others?",
                    Quote2="2. I hold firmly to my original views. After all I am a philosopher."
                }
            };
        }
        private bool _isAtStrart;

        public bool IsAtStrart
        {
            get { return this._isAtStrart; }
            set { this._isAtStrart = value; this.OnPropertyChanged("IsAtStrart"); }
        }

        private bool _isAtEnd;

        public bool IsAtEnd
        {
            get { return this._isAtEnd; }
            set { this._isAtEnd = value; this.OnPropertyChanged("IsAtEnd"); }
        }
        public Book Current
        {
            get { return this.books[currentBook]; }
        }
        private void Next()
        {
            if (this.books.Count - 1>this.currentBook)
            {
                this.currentBook++;
                this.OnPropertyChanged("Current");
                this.IsAtStrart = false;
                this.IsAtEnd = (this.books.Count - 1 == this.currentBook);
            }
        }
        private void Previous()
        {
            if(this.currentBook>0)
            {
                this.currentBook--;
                this.OnPropertyChanged("Current");
                this.IsAtEnd = false;
                this.IsAtStrart = (this.currentBook == 0);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged !=null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
