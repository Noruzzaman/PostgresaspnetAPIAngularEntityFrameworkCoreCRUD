using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPostgres.Models;

namespace WebAppPostgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureTypeController : ControllerBase
    {
        private readonly FurnitureDBContext _context;

        public FurnitureTypeController(FurnitureDBContext context)
        {
            _context = context;
        }


        //Get:api/FurnitureType
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FurnitureType>>> GetFurnitureType()
        {
            return await _context.FurnitureType.ToListAsync();
        }

        //Get By Id:api/FurnitureType/5
        [HttpGet("{FurnitureTypeID}")]
        public async Task<ActionResult<FurnitureType>> GetFurnitureType(int FurnitureTypeID)
        {
            var FurnitureType = await _context.FurnitureType.FindAsync(FurnitureTypeID);
            if (FurnitureType == null)
            {
                return NotFound();
            }
            return FurnitureType;
        }


        //For Update Put:api/FurnitureType/5
        [HttpPut("{FurnitureTypeID}")]
        public async Task<ActionResult> PutFurnitureType(int FurnitureTypeID, FurnitureType oFurnitureType)
        {
            if (FurnitureTypeID != oFurnitureType.FurnitureTypeID)
            {
                return BadRequest();
            }
            _context.Entry(oFurnitureType).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var FurnitureType = await _context.FurnitureType.FindAsync(FurnitureTypeID);
                if (FurnitureTypeID != FurnitureType.FurnitureTypeID)
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }


        //Post:api/FurnitureType
        [HttpPost]
        public async Task<ActionResult<FurnitureType>> PostFurnitureType(FurnitureType oFurnitureType)
        {

            _context.FurnitureType.Add(oFurnitureType);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFurnitureType", new { FurnitureTypeID = oFurnitureType.FurnitureTypeID }, oFurnitureType);
        }


        //Delete:api/FurnitureType/5
        [HttpDelete("{FurnitureTypeID}")]
        public async Task<ActionResult<FurnitureType>> DeleteFurnitureType(int FurnitureTypeID)
        {
            var FurnitureType = await _context.FurnitureType.FindAsync(FurnitureTypeID);
            if (FurnitureType == null)
            {
                return NotFound();
            }
            _context.FurnitureType.Remove(FurnitureType);
            await _context.SaveChangesAsync();

            return FurnitureType;
        }

    }
}