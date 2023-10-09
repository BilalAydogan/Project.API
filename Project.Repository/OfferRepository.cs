using Microsoft.EntityFrameworkCore;
using Project.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class OfferRepository : RepositoryBase<Offer>
    {
        public OfferRepository(RepositoryContext repositoryContext) : base(repositoryContext)
        {
            // Offer Tablosu Çakışıyor Onları Düzelt
        }
        public void DeleteOffer(int offerId)
        {
            RepositoryContext.Offers.Where(u => u.Id == offerId).ExecuteDelete();
        }
    }
}
