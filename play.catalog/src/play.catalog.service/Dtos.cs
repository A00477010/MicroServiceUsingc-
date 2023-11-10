using System;
using System.ComponentModel.DataAnnotations;
namespace play.catalog.service.Dto
{
    public record ItemDto(Guid id , string Name, string description , decimal price , DateTimeOffset createddate);
    public record createItem([Required]string name, string description, [Range(0,1000)]decimal price);
    public record updateItem([Required]string name , string description, [Range(0,1000)]decimal price);
    
} 