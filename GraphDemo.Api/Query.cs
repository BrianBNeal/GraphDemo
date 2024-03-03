namespace GraphDemo;

public class Query
{
    public IEnumerable<Book> GetBooks()
    {
        Author author = new("John Doe");
        yield return new Book("Book 1", author);
        yield return new Book("Book 2", author);
    }
}

public record Author(string Name);
public record Book(string Title, Author Author);
