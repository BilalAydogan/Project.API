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
        }
        public void DeleteOffer(int offerId)
        {
            RepositoryContext.Offers.Where(u => u.Id == offerId).ExecuteDelete();
        }
        public List<V_Offer> OfferOzet() => RepositoryContext.V_Offers.ToList<V_Offer>();
        public List<V_Offer> OfferByCompId(int id) => RepositoryContext.V_Offers.Where(x => x.CompanyId == id && x.Status > 0).OrderByDescending(x => x.RequestId).ToList();
        public List<V_Purchasing> PurchasingByCompId(int id) => RepositoryContext.V_Purchasings.Where(x => x.CompanyId == id && x.Status >= 1).ToList();
        public List<V_Purchasing> GeneralByCompId(int id) => RepositoryContext.V_Purchasings.Where(x => x.CompanyId == id && x.Status >= 1 && x.Price>=50).ToList();
        public List<V_Purchasing> ManagerByCompId(int id) => RepositoryContext.V_Purchasings.Where(x => x.CompanyId == id && x.Status >= 1 && x.Price < 50).ToList();
    }
}
