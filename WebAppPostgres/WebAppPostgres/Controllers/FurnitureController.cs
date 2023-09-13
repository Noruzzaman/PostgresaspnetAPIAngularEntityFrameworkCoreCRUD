using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAppPostgres.Models;

namespace WebAppPostgres.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FurnitureController : ControllerBase
    {
        private readonly FurnitureDBContext _context;

        public FurnitureController(FurnitureDBContext context)
        {
            _context = context;
        }


        //Get:api/Furniture
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Furniture>>> GetFurniture()
        {

            var furniture = (from e in _context.Furniture
                             join d in _context.FurnitureType
                             on e.FurnitureTypeID equals d.FurnitureTypeID

                             select new Furniture
                             {
                                 FurnitureId = e.FurnitureId,
                                 FurnitureName = e.FurnitureName,
                                 Brand = e.Brand,
                                 Cost = e.Cost,
                                 FurnitureTypeID = e.FurnitureTypeID,
                                 FurnitureTypeName = d.FurnitureTypeName


                             }
                             ).ToListAsync();

            return await furniture;
        }

        //Get By Id:api/Furniture/5
        [HttpGet("{FurnitureId}")]
        public async Task<ActionResult<Furniture>> GetFurniture(int FurnitureId)
        {
            var Furniture = await _context.Furniture.FindAsync(FurnitureId);
            if (FurnitureId == null)
            {
                return NotFound();
            }
            return Furniture;
        }


        //For Update Put:api/Furniture/5
        [HttpPut("{FurnitureId}")]
        public async Task<ActionResult> PutFurniture(int FurnitureId, Furniture oFurniture)
        {
            if (FurnitureId != oFurniture.FurnitureId)
            {
                return BadRequest();
            }
            _context.Entry(oFurniture).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                var Furniture = await _context.Furniture.FindAsync(FurnitureId);
                if (FurnitureId != Furniture.FurnitureId)
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


        //Post:api/Furniture
        [HttpPost]
        public async Task<ActionResult<Furniture>> PostFurniture(Furniture oFurniture)
        {

            _context.Furniture.Add(oFurniture);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetFurniture", new { FurnitureId = oFurniture.FurnitureId }, oFurniture);
        }


        //Delete:api/Furniture/5
        [HttpDelete("delete/{FurnitureId}")]
        public async Task<ActionResult<Furniture>> DeleteFurniture(int FurnitureId)
        {
            var Furniture = await _context.Furniture.FindAsync(FurnitureId);
            if (Furniture == null)
            {
                return NotFound();
            }
            _context.Furniture.Remove(Furniture);
            await _context.SaveChangesAsync();

            return Furniture;
        }



    }
}

