using play.catalog.service.Dto;
using Play.catalog.service.Entities;

namespace Play.catalog.service
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item){
            return new ItemDto(item.Id,item.name,item.desc,item.price,item.createdDate);
        }
    }
    
}