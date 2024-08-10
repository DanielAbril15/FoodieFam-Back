using FoodieFam_Back.Models;
using Microsoft.EntityFrameworkCore;

namespace FoodieFam_Back.Repository
{
    public class InstructionRepository
    {
        private FoodieFamContext _context;

        public InstructionRepository(FoodieFamContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<Instruction>> Get() =>
           await _context.Instructions.ToListAsync();

        public async Task<Instruction> GetById(Guid id) =>
            await _context.Instructions.FindAsync(id);

        public async Task Add(Instruction instruction) =>
            await _context.Instructions.AddAsync(instruction);

        public void Update(Instruction instruction)
        {
            _context.Instructions.Attach(instruction);
            _context.Instructions.Entry(instruction).State = EntityState.Modified;
        }

        public void Delete(Instruction instruction) =>
            _context.Instructions.Remove(instruction);

        public async Task Save() =>
            await _context.SaveChangesAsync();

    }
}
