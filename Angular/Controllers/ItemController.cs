using Angular.Context;
using Angular.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Angular.Controllers
{
    [Route("api/[controller]")]
    public class ItemController : Controller
    {
        IAuctionRepository _repository;
       
        public ItemController(IAuctionRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("[action]")]
        public JsonResult GetItems()
        {
            return Json(_repository.GetAllItems());
        }

        [HttpGet("[action]")]
        public JsonResult GetSilentItems()
        {
            return Json(_repository.GetSilentItems());
        }

        [HttpGet("[action]")]
        public JsonResult GetLiveItems()
        {
            return Json(_repository.GetLiveItems());
        }

        [HttpPost("[action]")]
        public async Task<JsonResult> AddSilentItem([FromBody]NewItem item)
        {
            Item newItem = new Item
            {
                Description = item.Description,
                Number = item.Number,
                Type = "Silent"
            };

            _repository.AddNewItem(newItem);
            if (await _repository.SaveChangesAsync())
            {
                return Json(item);
            }

            return Json(null);
        }

        [HttpPost("[action]")]
        public async Task<JsonResult> AddLiveItem(NewItem item)
        {
            Item newItem = new Item
            {
                Description = item.Description,
                Number = item.Number,
                Type = "Live"
            };

            _repository.AddNewItem(newItem);
            if (await _repository.SaveChangesAsync())
            {
                return Json(item);
            }

            return Json(null);
        }

        [HttpPost("[action]")]
        public async Task<JsonResult> DeleteItem([FromBody]Item item)
        {
            _repository.DeleteItem(item.ID);
            await _repository.SaveChangesAsync();
 
            return Json(null);
        }

        [HttpPost("[action]")]
        public async Task<JsonResult> EditItem([FromBody] Item item)
        {
            var itemDb = _repository.GetItem(item.ID);
            if (itemDb != null)
            {
                _repository.EditItem(itemDb);
                itemDb.Number = item.Number;
                itemDb.Description = item.Description;
                if (await _repository.SaveChangesAsync())
                {
                    return Json(itemDb);
                }

            }
            return Json("error");
        }
    }

    public class NewItem
    {
        public string Number { get; set; }
        public string Description { get; set; }
    }
}
