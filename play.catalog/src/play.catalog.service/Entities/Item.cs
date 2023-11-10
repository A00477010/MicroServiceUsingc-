using System;
using play.catalog.service.Dto;

namespace Play.catalog.service.Entities

{
    public class Item
    {
        public Guid Id{get;set;}
        public String name{get; set;}
        public String desc{get; set;}
        public decimal price{get; set;}
        public DateTimeOffset createdDate{get; set;}

        // internal  ItemDto AsDto()
        // {
        //     throw new NotImplementedException();
        // }
    }

    
}