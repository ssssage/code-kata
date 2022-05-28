using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kata.HarryPotter
{
    public class BookPriceCalculator
    {
        #region Members

        private const Decimal singlePrice = 8;
        private const Decimal twoBooksDiscountFactor = 0.95m;
        private const Decimal threeBooksDiscountFactor = 0.9m;
        private const Decimal fourBooksDiscountFactor = 0.8m;
        private const Decimal fiveBooksDiscountFactor = 0.75m;

        #endregion

        #region Methods

        public Decimal Calculate(List<Int32> books)
        {
            if (!books.Any())
                return 0;

            List<BooksCombo> combos = this.CalculateCombos(books);

            Decimal minPrice = Decimal.MaxValue;

            foreach (BooksCombo combo in combos)
            {
                Decimal comboPrice = CalculateComboPrice(combo);

                if (comboPrice < minPrice)
                {
                    minPrice = comboPrice;
                }
            }

            return minPrice;
        }

        private Decimal CalculateComboPrice(BooksCombo combo)
        {
            Decimal comboPrice = 0;

            foreach (List<Int32> books in combo.Groups)
            {
                Decimal discountFactor = CalculateDiscountFactor(books);
                comboPrice += books.Count * singlePrice * discountFactor;
            }

            return comboPrice;
        }

        private List<BooksCombo> CalculateCombos(List<Int32> books)
        {
            List<BooksCombo> combos = new List<BooksCombo>();

            for (Int32 i = 1; i <= books.Distinct().Count(); i++)
            {
                BooksCombo combo = new BooksCombo();

                foreach (Int32 book in books)
                {
                    IEnumerable<List<Int32>> groups = combo.GetGroupsThatDoNotContainBook(book);

                    List<Int32> group = groups.FirstOrDefault(g => g.Count < i);
                    if (group != null)
                    {
                        group.Add(book);
                    }
                    else
                    {
                        combo.AddBook(book);
                    }
                }

                combos.Add(combo);
            }

            return combos;
        }

        private Decimal CalculateDiscountFactor(List<Int32> books)
        {
            if (books.Distinct().Count() == 2)
            {
                return twoBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 3)
            {
                return threeBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 4)
            {
                return fourBooksDiscountFactor;
            }
            else if (books.Distinct().Count() == 5)
            {
                return fiveBooksDiscountFactor;
            }
            else
            {
                return 1;
            }
        }

        #endregion

    }
}
