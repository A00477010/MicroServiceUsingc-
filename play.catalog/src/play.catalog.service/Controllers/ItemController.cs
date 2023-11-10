using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using play.catalog.service.Dto;
using Play.catalog.service.Repositories;    
using Play.catalog.service;
using Play.catalog.service.Entities;

namespace play.catalog.service.controller
{
    [ApiController]
    [Route("items")]
    public class ItemsController:ControllerBase
    {

        private readonly ItemRepository itemRepository= new();
        
        
        
        // private static readonly List<ItemDto> items= new(){
        //     new ItemDto(Guid.NewGuid(),"Potion","Restores small amount of health",10,DateTimeOffset.UtcNow),
        //     new ItemDto(Guid.NewGuid(),"Antidote","Recovers from death",11,DateTimeOffset.UtcNow),
        //     new ItemDto(Guid.NewGuid(),"Sword","Helps kill enimies",12,DateTimeOffset.UtcNow)
        // };



        [HttpGet]
        public async Task<IEnumerable<ItemDto>>Get()
        {
            var items =(await itemRepository.GetAllAsync()).Select(item=>item.AsDto());
            return items;


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ItemDto>> GetById(Guid id){
            // var item =items.Where(item=>item.id==id).SingleOrDefault();
            var item =await itemRepository.GetAsync(id);
            if (item==null){
                return NotFound();
            }
            return item.AsDto();

        }

        [HttpPost]
        public async Task<ActionResult<ItemDto>> PostCreateItem(createItem createItem){
            // var item = new Item{
            //     // Id=Guid.NewGuid(),
            //     name=createItem.name,
            //     desc=createItem.description,
            //     price=createItem.price,
            //     createdDate=DateTimeOffset.UtcNow
            // };
            // await itemRepository.CreateAsync(item);

            // return CreatedAtAction(nameof(GetById),item);
            // var item=new Item (
            // Name =createItem.name,
            // Description =createItem.description,
            // Price =createItem.price,
            // CreatedDate=DateTimeOffset.UtcNow);
            // await itemRepository.CreateAsync(item);

            // return CreatedAtAction(nameof(GetById),new{id=item.id},item);
            return NoContent();


        }
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(Guid id, updateItem updateItemDto)
        {
            var existingItem= await itemRepository.GetAsync(id);
            // var existingItem=items.Where(item=>item.id==id).SingleOrDefault();
            existingItem.name=updateItemDto.name;
            existingItem.desc=updateItemDto.description;
            existingItem.price=updateItemDto.price;

            await itemRepository.updateAsync(existingItem);

            // var updatedItem=existingItem with{
            //     Name=updateItemDto.name,description=updateItemDto.description,price=updateItemDto.price
            // };
            // var index=items.FindIndex(existingItem=>existingItem.id==id);
            // items[index]=updatedItem;
            return NoContent();
        


        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> deleteItem(Guid id){
            var item =await itemRepository.GetAsync(id);
            await itemRepository.RemoveAsync(item.Id);
            // var itemToBeDeleted= items.Where(items=>items.id==id).SingleOrDefault();
            // items.Remove(itemToBeDeleted);
            return NoContent();

        }


    }
    
}