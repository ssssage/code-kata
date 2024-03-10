using HarryPotterKata.Enumerations;

namespace HarryPotterKata.Models
{
    // This class represents a book.
    public class Book
    {
        // This property represents the price of the book.
        // It is read-only and its value is set to 8.
        public double BookPrice { get; } = 8;

        // This property represents the volume of the book.
        // It is of type BookVolumeEnum, which is an enumeration representing the different volumes of a book.
        public BookVolumeEnum BookVolume { get; }

        // This is the constructor of the Book class.
        // It takes one parameter, bookVolume, which is of type BookVolumeEnum.
        public Book(BookVolumeEnum bookVolume)
        {
            // The bookVolume parameter is assigned to the BookVolume property.
            // This means that when a new Book object is created, its BookVolume property is set to the value of the bookVolume parameter.
            BookVolume = bookVolume;
        }
    }

}
