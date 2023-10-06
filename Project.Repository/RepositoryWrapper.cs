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
        private StorageRepository storageRepository;
        private RequestRepository requestRepository;
        private RequestOnayRepository requestOnayRepository;
        private RequestSupplyRepository requestSupplyRepository;
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
        public StorageRepository StorageRepository
        {
            get
            {
                if (storageRepository == null)
                    storageRepository = new StorageRepository(context);
                return storageRepository;

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
        public CompanyRepository CompanyRepository
        {
            get
            {
                if (companyRepository == null)
                    companyRepository = new CompanyRepository(context);
                return companyRepository;

            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
