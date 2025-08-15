namespace Bank.Core.Repositories;

public interface IPaginate<T>
{
    int From { get; }
    int Index { get; }
    int Size { get; }
    int Count { get; }
    int Pages { get; }
    IList<T> Items { get; }
    bool HasPrevious { get; }
    bool HasNext { get; }
}

public class Paginate<T> : IPaginate<T>
{
    public Paginate(IEnumerable<T> source, int index, int size, int from)
    {
        var enumerable = source as T[] ?? source.ToArray();
        Count = enumerable.Length;
        Pages = (int)Math.Ceiling(Count / (double)size);
        Index = index;
        Size = size;
        From = from;
        Items = enumerable.Skip(from).Take(size).ToList();
    }

    public Paginate()
    {
        Items = new T[0];
    }

    public int From { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public IList<T> Items { get; set; }
    public bool HasPrevious => Index - From > 0;
    public bool HasNext => Index - From + 1 < Pages;
}

public class PaginationParams
{
    private int _pageSize = 10;
    private int _pageIndex = 0;
    private const int MaxPageSize = 50;

    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value < 0 ? 0 : value;
    }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value < 1 ? 1 : value;
    }
}
