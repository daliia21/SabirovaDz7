using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DzFromTumakov.AbstractModels
{

    class Song
    {
        private string name;
        private string author;
        private Song prev;


        public void SetAuthor(string author)
        {
            this.author = author;
        }
        public void SetPreviousSong(Song prev)
        {
            this.prev = prev;
        }
        public string Title()
        {
            return $"{name} - {author}";
        }

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Song))
            {
                return false;
            }

            Song other = (Song)obj;
            return name == other.name && author == other.author;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(name, author);
        }

        public Song(string name, string author, Song prev = null)
        {
            this.name = name;
            this.author = author;
            this.prev = prev;
        }
        public void PrintChain()
        {
            Song current = this;
            while (current != null)
            {
                Console.WriteLine(current.Title());
                current = current.prev;
            }
        }

    }

}
