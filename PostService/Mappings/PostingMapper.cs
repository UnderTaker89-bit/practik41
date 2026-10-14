using PostService.Dtos;
using PostService.Models;

namespace PostService.Mappings;

public static class PostingMapper
{
    public static PostingGetDto ToPostingGetDto(Posting model)
    {
        return new PostingGetDto
        {
            Id = model.Id,
            From = model.From,
            To = model.To,
            Content = model.Content,
            DeliveryType = model.DeliveryType,
            Weight = model.Weight,
            Width = model.Width,
            Height = model.Height,
            Depth = model.Depth,
            Value = model.Value,
            Price = model.Price,
            CreatedAt = model.CreatedAt
        };
    }

    public static Posting ToPosting(PostingPostDto dto)
    {
        return new Posting
        {
            From = dto.From,
            To = dto.To,
            Content = dto.Content,
            DeliveryType = dto.DeliveryType,
            Weight = dto.Weight,
            Width = dto.Width,
            Height = dto.Height,
            Depth = dto.Depth,
            Value = dto.Value,
            Price = dto.Price,
            CreatedAt = DateTime.UtcNow
        };
    }

    public static Posting ToPosting(PostingPutDto dto)
    {
        return new Posting
        {
            Id = dto.Id,
            From = dto.From,
            To = dto.To,
            Content = dto.Content,
            DeliveryType = dto.DeliveryType,
            Weight = dto.Weight,
            Width = dto.Width,
            Height = dto.Height,
            Depth = dto.Depth,
            Value = dto.Value,
            Price = dto.Price,
            CreatedAt = dto.CreatedAt
        };
    }
}