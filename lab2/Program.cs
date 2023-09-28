using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;

class Program
{
    public static void Main()
    {
        var publishers = CountBooksByPublisher();
        foreach (var pub in publishers)
            Console.WriteLine($"{pub.Key} {pub.Value}");

        var readers = GetReaders("George R. R. Martin");
        foreach (var reader in readers)
            Console.WriteLine(reader);

        var book = GetUnreturnedBooks();
        Console.WriteLine(book);
        Console.ReadLine();
    }
    private static List<Book> books = new List<Book>(){
        new Book(){
            Code=1,
            Title ="C# in Depth",
            Author ="Jon Skeet",
            Publisher = "Manning"
        },
        new Book(){
            Code=2,
            Title ="Clean Code",
            Author ="Robert C. Martin",
            Publisher = "Pearson"
        },
        new Book(){
            Code=3,
            Title ="A Game of Thrones",
            Author ="George R. R. Martin",
            Publisher = "Voyager Books"
        },
        new Book(){
            Code=4,
            Title ="A Clash of Kings",
            Author ="George R. R. Martin",
            Publisher = "Voyager Books"
        },
        new Book(){
            Code=5,
            Title ="A Storm of Swords",
            Author ="George R. R. Martin",
            Publisher = "Voyager Books"
        }
    };

    private static List<Reader> readers = new List<Reader>(){
        new Reader(){
            Surname = "Andrashko",
            BookCodes = new List<int>{1,2,3},
            TakeDates = new List<DateOnly>() {
                new DateOnly(2018,10,18),
                new DateOnly(2021,9,27),
                new DateOnly(2021,9,27),
            },
            ReturnDates = new List<DateOnly?>() {
                new DateOnly(2019,10,18),
                new DateOnly(2023,9,28),
                null,
            }
        },
        new Reader(){
            Surname = "Shkiria",
            BookCodes = new List<int>{3,4,5},
            TakeDates = new List<DateOnly>() {
                new DateOnly(2021,1,1),
                new DateOnly(2021,1,1),
                new DateOnly(2022,1,1),
            },
            ReturnDates = new List<DateOnly?>() {
                null,
                null,
                new DateOnly(2023,9,28),
            }
        }

    };

    private static Dictionary<string, int> CountBooksByPublisher()
    {
        Dictionary<string, int> publishers = books
        .GroupBy(
            book => book.Publisher
        ).ToDictionary(
            publisher => publisher.Key,
            publisher => publisher.Count()
        );

        return publishers;
    }

    private static List<string> GetReaders(string Author)
    {
        int SEARCH_YEAR = DateTime.Now.Year - 2;
        const int MIN_TIMES = 2;

        var readersWithHistory = readers
        .Select(reader => new
        {
            reader = reader,
            history = reader.BookCodes
            .Zip(
                reader.TakeDates,
                (code, date) => new
                {
                    Code = code,
                    takeDate = date
                })
            .Zip(
                    reader.ReturnDates,
                    (zip, date) => new
                    {
                        Book = books.First(book => book.Code == zip.Code),
                        takeDate = zip.takeDate,
                        returnDate = date
                    }
            )
            .ToList()
        }).ToList();
        // фільтр по року
        var filteredReadersWithHistory = readersWithHistory
        .Select(
            readerWithHistory => new
            {
                reader = readerWithHistory.reader,
                history = readerWithHistory.history
                .Where(
                    history => history.takeDate.Year == SEARCH_YEAR
                ).ToList()
            }
        ).ToList();
        //фільтр по прізвищу 

        filteredReadersWithHistory = filteredReadersWithHistory
        .Select(
             readerWithHistory => new
             {
                 reader = readerWithHistory.reader,
                 history = readerWithHistory.history
                 .Where(
                    history => history.Book.Author == Author
                 ).ToList()
             }
         ).ToList();
        return filteredReadersWithHistory
        .Where(
            readerWithHistory => readerWithHistory.history.Count() >= MIN_TIMES
        ).Select(
            readerWithHistory => readerWithHistory.reader.Surname
        ).ToList();
    }

    private static string GetUnreturnedBooks()
    {
        var readersWithHistory = readers
        .Select(reader => new
        {
            reader = reader,
            history = reader.BookCodes
            .Zip(
                reader.TakeDates,
                (code, date) => new
                {
                    Code = code,
                    takeDate = date
                })
            .Zip(
                    reader.ReturnDates,
                    (zip, date) => new
                    {
                        Book = books.First(book => book.Code == zip.Code),
                        takeDate = zip.takeDate,
                        returnDate = date
                    }
            )
            .ToList()
        }).ToList();
        //вибір неповернутих книг
        var unreturnedBooks = readersWithHistory
        .SelectMany(
            readerWithHistory => readerWithHistory.history
        ).Where(
            record => record.returnDate == null
        ).ToList();
        var groupedUnreturnedBooks = unreturnedBooks.GroupBy(
            record => record.Book.Title
        ).ToList();
        var res = groupedUnreturnedBooks
        .OrderByDescending(
            record => record.Count()
        )
        .Select(
            record => record.Key
        ).ToList();

        return res.First();
    }
}


class Book
{
    public int Code { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public string Publisher { get; set; }
}

class Reader
{
    public string Surname { get; set; }
    public List<int> BookCodes { get; set; }
    public List<DateOnly> TakeDates { get; set; }
    public List<DateOnly?> ReturnDates { get; set; }
}