using DemoApp.Data;
using DemoApp.Model;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DemoApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RoomModelController : ControllerBase
    {
        public readonly ApplicationDbcontex _db;
        public RoomModelController(ApplicationDbcontex db)
        {
            _db = db;
        }
    

        [HttpGet]
        public  async Task<ActionResult<IEnumerable<RoomModel>>> GetRoom()
        {
            var  result = await _db.RoomModels.ToListAsync();
            return result;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RoomModel>> Getdata(string id)
        {
            var result = await _db.RoomModels.FindAsync(id);
            if (result == null) 
                return NotFound();


            return result;


        }

        [HttpPost]
        public async Task<ActionResult<RoomModel>> create(RoomModel roomModel)
        {
            if (roomModel == null)
            {
                return NotFound();
            }

            _db.RoomModels.Add(roomModel);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

            return CreatedAtAction("Getdata", new { id = roomModel.RoomID }, roomModel);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRoom(string id, RoomModel updatedRoom)
        {
            try
            {
                if (id != updatedRoom.RoomID)
                {
                    return BadRequest("Room ID mismatch.");
                }

                var room = await _db.RoomModels.FindAsync(id);
                if (room == null)
                {
                    return NotFound($"Room with ID {id} not found.");
                }

                // Update properties
                room.RoomCategory = updatedRoom.RoomCategory;
                room.RoomCapacity = updatedRoom.RoomCapacity;
                room.RoomPrice = updatedRoom.RoomPrice;

                await _db.SaveChangesAsync();
                return Ok(room);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating data: {ex.Message}");
            }
        }

      
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var room = await _db.RoomModels.FindAsync(id);
            if (room == null)
            {
                return NotFound(new { Message = $"Room with ID {id} not found." });
            }

            _db.RoomModels.Remove(room);
            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = "Error deleting data.", Details = ex.Message });
            }

            return Ok(new { Message = "Room deleted successfully.", Room = room });
        }
    }


    // Old Code..
    /*
        [HttpPost]
        public IActionResult create(RoomModel roomModel) { 



                _db.RoomModels.Add(roomModel);
                _db.SaveChanges();

            return new JsonResult(Ok(roomModel));

        }
        [HttpGet]
        public IActionResult get(string RoomId)
        {
            var room = _db.RoomModels.Find(RoomId);
            if (room == null)
                return new JsonResult(NotFound());

            return new JsonResult(Ok(room));
        }
        [HttpDelete]
        public IActionResult Delete(string RoomId)
        {
            var room = _db.RoomModels.Find(RoomId);
            if(room == null)
                return new JsonResult(NotFound());

            _db.RoomModels.Remove(room);
            _db.SaveChanges();
            return new JsonResult(Ok(room));

        }
        [HttpGet]
        public IActionResult GetallRoom()
        {
            var List = _db.RoomModels.ToList();
            return new JsonResult(List);
        }
        */

}

