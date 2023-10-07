using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class OferRepository : RepositoryBase<Ofer>
    {
        public OferRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            // Offer Tablosu Çakışıyor Onları Düzelt
        }
        public void DeleteOfer(int oferId)
        {
            RepositoryContext.Ofers.Where(u => u.Id == oferId).ExecuteDelete();
        }
    }
}
