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
        private CompanyRepository companyRepository;
        private DepartmentRepository departmentRepository;
        private OfferRepository offerRepository;
        private RequestRepository requestRepository;
        private RolRepository rolRepository;
        private StorageRepository storageRepository;
        private UserRepository userRepository;
        private UserDepartmentRepository userDepartmentRepository;
        private UserRolRepository userRolRepository;
        
        
        
        public RepositoryWrapper(RepositoryContext context)
        {
            this.context = context;
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
        public DepartmentRepository DepartmentRepository
        {
            get
            {
                if (departmentRepository == null)
                    departmentRepository = new DepartmentRepository(context);
                return departmentRepository;

            }
        }

        public OfferRepository OfferRepository
        {
            get
            {
                if (offerRepository == null)
                    offerRepository = new OfferRepository(context);
                return offerRepository;

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
        public RolRepository RolRepository
        {
            get
            {
                if (rolRepository == null)
                    rolRepository = new RolRepository(context);
                return rolRepository;

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
        public UserRepository UserRepository
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(context);
                return userRepository;

            }
        }
        public UserDepartmentRepository UserDepartmentRepository
        {
            get
            {
                if (userDepartmentRepository == null)
                    userDepartmentRepository = new UserDepartmentRepository(context);
                return userDepartmentRepository;

            }
        }
        public UserRolRepository UserRolRepository
        {
            get
            {
                if (userRolRepository == null)
                    userRolRepository = new UserRolRepository(context);
                return userRolRepository;

            }
        }

        public void SaveChanges()
        {
            context.SaveChanges();
        }
    }
}
