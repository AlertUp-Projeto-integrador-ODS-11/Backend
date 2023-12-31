﻿using AlertUp.Data;
using AlertUp.Model;
using Microsoft.EntityFrameworkCore;

namespace AlertUp.Service.Implements
{
    public class PostagemService : IPostagemService
    {
        private readonly AppDbContext _context;

        public PostagemService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Postagem>> GetAll()
        {
            return await _context.Postagens
                .Include(t => t.Tema)
                .Include(u => u.User)
                .ToListAsync();
        }

        public async Task<Postagem?> GetById(long id)
        {
            try
            {
                var Postagem = await _context.Postagens
                    .Include(t => t.Tema)
                    .Include(u => u.User)
                    .FirstOrDefaultAsync(i => i.Id == id);
                return Postagem;
            }
            catch

            {
                return null;
            }
        }

        public async Task<IEnumerable<Postagem>> GetByTitulo(string titulo)
        {
            var Postagem = await _context.Postagens
                .Include(t => t.Tema)
                .Include(u => u.User)
                .Where(p => p.Titulo.Contains(titulo))
                .ToListAsync();
            return Postagem;
        }

        public async Task<Postagem?> Curtir(long id)
        {
            var postagem = await _context.Postagens
                .Include(p => p.Tema)
                .Include(u => u.User)
                .FirstOrDefaultAsync(p => p.Id == id);
            if (postagem is null)
                return null;
            postagem.Relevancia += 1;
            _context.Update(postagem);
            await _context.SaveChangesAsync();
            return postagem;
        }

        public async Task<Postagem?> Create(Postagem postagem)
        {
            if (postagem.Tema is not null)
            {
                var BuscaTema = await _context.Temas.FindAsync(postagem.Tema.Id);

                if (BuscaTema is null)
                    return null;
            }

            postagem.Tema = postagem.Tema is not null ? _context.Temas.FirstOrDefault(t => t.Id == postagem.Tema.Id) : null;
            postagem.User = postagem.User is not null ? _context.Users.FirstOrDefault(u => u.Id == postagem.User.Id) : null;

            await _context.Postagens.AddAsync(postagem);
            await _context.SaveChangesAsync();

            return postagem;
            
        }

        public async Task<Postagem?> Update(Postagem postagem)
        {
            var PostagemUpdate = await _context.Postagens.FindAsync(postagem.Id);

            if (PostagemUpdate is null)
            {
                return null;
            }
            if (postagem.Tema is not null)
            {
                var BuscaTema = await _context.Temas.FindAsync(postagem.Tema.Id);

                if (BuscaTema is null)
                    return null;
                postagem.Tema = BuscaTema;
            }

            postagem.User = postagem.User is not null ? await _context.Users.FirstOrDefaultAsync(u => u.Id == postagem.User.Id) : null;

            _context.Entry(PostagemUpdate).State = EntityState.Detached;
            _context.Entry(postagem).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return postagem;
        }

        public async Task Delete(Postagem postagem)
        {
            _context.Postagens.Remove(postagem);
            await _context.SaveChangesAsync();
        }

    }
}
