using System;

namespace InterfaceAdapter_Adapter.Dtos;

public class PostServiceDto
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public string Title { get; set; }
    public string Body { get; set; }
}
