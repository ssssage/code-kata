using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.HarryPotter
{
    public class BooksCombo
    {
        private List<List<Int32>> _bookGroups;

        public BooksCombo()
        {
            this._bookGroups = new List<List<Int32>>();
        }

        public void AddBook(Int32 book)
        {
            this._bookGroups.Add(new List<Int32>{ book });
        }

        public void AddBooks(params Int32[] books)
        {
            this._bookGroups.Add(new List<Int32>(books));
        }

        public IEnumerable<List<Int32>> GetGroupsThatDoNotContainBook(Int32 book)
        {
            return this._bookGroups.Where(bg => !bg.Contains(book));
        }

        public IReadOnlyCollection<List<Int32>> Groups
        {
            get
            {
                return this._bookGroups.AsReadOnly();
            }
        }

    }
}
