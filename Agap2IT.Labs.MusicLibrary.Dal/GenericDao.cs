using Agap2IT.Labs.MusicLibrary.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agap2IT.Labs.MusicLibrary.Dal
{

    public class GenericDao
    {
        public async Task AddAsync<T>(T genericObject)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(genericObject).State = Microsoft.EntityFrameworkCore.EntityState.Added;
                await context.SaveChangesAsync();
            }
        }



        public async Task UpdateAsync<T>(T genericObject)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(genericObject).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteAsync<T>(T genericObject)
        {
            using (var context = new AcademyAgap2202211Context())
            {
                context.Entry(genericObject).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                await context.SaveChangesAsync();
            }
        }



        public async Task<T> GetAsync<T>(int id) where T : class
        {
            using (var context = new AcademyAgap2202211Context())
            {
                return await context.Set<T>().FindAsync(id);
            }
        }
    }
}

