using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Repository
{
    public class RepositoryWrapper
    {
        private RepositoryContext context;
        private RolRepository rolRepository;
        private UserRepository userRepository;
        private DepartmentRepository departmentRepository;
        private DepoRepository depoRepository;
        private ItemRepository itemRepository;
        private RequestRepository requestRepository;
        private RequestOnayRepository requestOnayRepository;
        private RequestSupplyRepository requestSupplyRepository;
        private SupplyRepository supplyRepository;
        private CompanyRepository companyRepository;
        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
        }

        
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;

            }
        }
        public CompanyRepository CompanyRepository
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(context);
                return companyRepository;

            }
        }
        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;

            }
        }
        public DepartmentRepository DepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(context);
                return departmentRepository;

            }
        }
        public DepoRepository DepoRepository
        {
            get
            {
                if (depoRepository == null)
                    depoRepository = new DepoRepository(context);
                return depoRepository;

            }
        }
        public ItemRepository ItemRepository
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(context);
                return itemRepository;

            }
        }
        public RequestRepository RequestRepository
        {
            get
            {
                if (requestRepository == null)
                    requestRepository = new RequestRepository(context);
                return requestRepository;

            }
        }
        public RequestOnayRepository RequestOnayRepository
        {
            get
            {
                if (requestOnayRepository == null)
                    requestOnayRepository = new RequestOnayRepository(context);
                return requestOnayRepository;

            }
        }
        public RequestSupplyRepository RequestSupplyRepository
        {
            get
            {
                if (requestSupplyRepository == null)
                    requestSupplyRepository = new RequestSupplyRepository(context);
                return requestSupplyRepository;

            }
        }
        public SupplyRepository SupplyRepository
        {
            get
            {
                if (supplyRepository == null)
                    supplyRepository = new SupplyRepository(context);
                return supplyRepository;

            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
