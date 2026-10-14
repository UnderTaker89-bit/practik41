using PostService.CommonTypes;

namespace PostService.Dtos;

public class PostingPostDto
{
    public string From { get; set; } = null!;
    public string To { get; set; } = null!;
    public string Content { get; set; } = null!;
    public DeliveryType DeliveryType { get; set; }
    public float Weight { get; set; }
    public float Width { get; set; }
    public float Height { get; set; }
    public float Depth { get; set; }
    public float Value { get; set; }
    public float Price { get; set; }
}