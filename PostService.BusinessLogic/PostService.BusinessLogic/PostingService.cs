using PostService.CommonTypes;
using PostService.Models;

namespace PostService.BusinessLogic;

public class PostingService : IPostingService
{
    private static readonly List<Posting> _postings = new()
    {
        new Posting
        {
            Id = 1,
            From = "Alice",
            To = "Bob",
            Content = "Books",
            DeliveryType = DeliveryType.Courier,
            Weight = 2.5f,
            Width = 30f,
            Height = 20f,
            Depth = 10f,
            Value = 50.0f,
            Price = 60.0f,
            CreatedAt = DateTime.UtcNow
        },
        new Posting
        {
            Id = 2,
            From = "Oleh",
            To = "Iryna",
            Content = "Electronics",
            DeliveryType = DeliveryType.Department,
            Weight = 1.1f,
            Width = 15f,
            Height = 10f,
            Depth = 5f,
            Value = 120.0f,
            Price = 31.0f,
            CreatedAt = DateTime.UtcNow
        }
    };

    private static int _nextId = 3;

    public List<Posting> GetAll()
    {
        return _postings;
    }

    public Posting? Find(int postingId)
    {
        Posting? found = null;
        foreach (var item in _postings)
        {
            if (item.Id == postingId)
            {
                found = item;
                break;
            }
        }
        return found;
    }

    public Posting Create(Posting newPosting)
    {
        newPosting.Id = _nextId++;
        newPosting.CreatedAt = DateTime.UtcNow;

        float baseRate = newPosting.DeliveryType switch
        {
            DeliveryType.Department => 20.0f,
            DeliveryType.Courier => 35.0f,
            DeliveryType.ExpressCourier => 60.0f,
            _ => 20.0f
        };

        newPosting.Price = baseRate + (newPosting.Weight * 10.0f);

        _postings.Add(newPosting);
        return newPosting;
    }

    public Posting? Update(Posting posting)
    {
        Posting? target = null;
        foreach (var item in _postings)
        {
            if (item.Id == posting.Id)
            {
                target = item;
                break;
            }
        }

        if (target is null)
            return null;

        target.From = posting.From;
        target.To = posting.To;
        target.Content = posting.Content;
        target.DeliveryType = posting.DeliveryType;
        target.Weight = posting.Weight;
        target.Width = posting.Width;
        target.Height = posting.Height;
        target.Depth = posting.Depth;
        target.Value = posting.Value;
        target.Price = posting.Price;

        return target;
    }

    public int Delete(int postingId)
    {
        int index = -1;
        for (int i = 0; i < _postings.Count; i++)
        {
            if (_postings[i].Id == postingId)
            {
                index = i;
                break;
            }
        }

        if (index == -1)
            return 0;

        _postings.RemoveAt(index);
        return 1;
    }
}