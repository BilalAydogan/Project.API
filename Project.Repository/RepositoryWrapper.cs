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
        private ProductRepository productRepository;
        private ProductOnayRepository productOnayRepository;
        private ProductSupplyRepository productSupplyRepository;
        private SupplyRepository supplyRepository;
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
        public ProductRepository ProductRepository
        {
            get
            {
                if (productRepository == null)
                    productRepository = new ProductRepository(context);
                return productRepository;

            }
        }
        public ProductOnayRepository ProductOnayRepository
        {
            get
            {
                if (productOnayRepository == null)
                    productOnayRepository = new ProductOnayRepository(context);
                return productOnayRepository;

            }
        }
        public ProductSupplyRepository ProductSupplyRepository
        {
            get
            {
                if (productSupplyRepository == null)
                    productSupplyRepository = new ProductSupplyRepository(context);
                return productSupplyRepository;

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
