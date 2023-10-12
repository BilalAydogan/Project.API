using Microsoft.EntityFrameworkCore;
using Project.Model;
using Project.Model.Views;
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
        public List<V_Offer> OfferOzet() => RepositoryContext.V_Offers.ToList<V_Offer>();

        public List<V_Offer> OfferByCompId(int id) => RepositoryContext.V_Offers.Where(x => x.CompanyId == id && x.Status == 1).ToList();
    }
}
