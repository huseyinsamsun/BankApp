namespace BankingCreditSystem.Core.Repositories;

public class Paginate<T> : IPaginate<T>
{
    public int From { get; set; }
    public IList<T> Items { get; set; }
    public int Index { get; set; }
    public int Size { get; set; }
    public int Count { get; set; }
    public int Pages { get; set; }
    public bool HasPrevious => Index > 0;
    public bool HasNext => Index + 1 < Pages;

    public Paginate()
    {
        Items = new List<T>();
    }

    public Paginate(IEnumerable<T> source, int index, int size, int from)
    {
        Index = index;
        Size = size;
        From = from;
        Items = source.ToList();
        Count = Items.Count;
        Pages = (int)Math.Ceiling(Count / (double)Size);
    }
} 