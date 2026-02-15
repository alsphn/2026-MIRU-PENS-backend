using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MIRU.API.Data;
using MIRU.API.Models;

namespace MIRU.API.Controllers
{
    // [Route] menentukan alamat API. [controller] otomatis diganti nama class (Peminjaman)
    // Jadi alamatnya nanti: api/peminjaman
    [Route("api/[controller]")]
    [ApiController]
    public class PeminjamanController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor: Minta akses ke database (Dependency Injection)
        public PeminjamanController(AppDbContext context)
        {
            _context = context;
        }

        // 1. GET: api/peminjaman
        // Mengambil SEMUA data peminjaman
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Peminjaman>>> GetPeminjaman()
        {
            return await _context.Peminjamans.ToListAsync();
        }

        // 2. GET: api/peminjaman/5
        // Mengambil SATU data berdasarkan ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Peminjaman>> GetPeminjaman(int id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);

            if (peminjaman == null)
            {
                return NotFound("Data tidak ditemukan.");
            }

            return peminjaman;
        }

        // 3. POST: api/peminjaman
        // Menambahkan data BARU
        [HttpPost]
        public async Task<ActionResult<Peminjaman>> PostPeminjaman(Peminjaman peminjaman)
        {
            _context.Peminjamans.Add(peminjaman);
            await _context.SaveChangesAsync();

            // Mengembalikan info lokasi data baru (best practice REST API)
            return CreatedAtAction("GetPeminjaman", new { id = peminjaman.Id }, peminjaman);
        }

        // 4. PUT: api/peminjaman/5
        // Mengubah/Update data yang sudah ada
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPeminjaman(int id, Peminjaman peminjaman)
        {
            if (id != peminjaman.Id)
            {
                return BadRequest("ID tidak cocok.");
            }

            _context.Entry(peminjaman).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PeminjamanExists(id))
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

        // 5. DELETE: api/peminjaman/5
        // Menghapus data
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePeminjaman(int id)
        {
            var peminjaman = await _context.Peminjamans.FindAsync(id);
            if (peminjaman == null)
            {
                return NotFound();
            }

            _context.Peminjamans.Remove(peminjaman);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Fungsi bantuan untuk cek apakah data ada
        private bool PeminjamanExists(int id)
        {
            return _context.Peminjamans.Any(e => e.Id == id);
        }
    }
}