using Demo.BLL.Interfaces;
using Demo.DAL.Context;
using Demo.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.BLL.Repositories
{
    internal class DepartmentRepository : IDepartmentRepository
    {
        //till this point we didn`t open the Connection with the DataBase
        private readonly MVCAppDemoDbcontext _dbContext;

        public DepartmentRepository(MVCAppDemoDbcontext dbContext)
        {
            //this way we will Connect with the DataBase Only when we Call the DepartmentRepository
            /*dbContext = new MVCAppDemoDbcontext();*/
            // there is an Issue in this Way  
            /// the issue is some cases i need to make two instance of the same Class that mean the Ctor Will be called 2 times each time 
            /// will in initialize dbContext two times means 2 dataBase Connection !!
            /// To Fix that we Will Make the CLR Handle that 
            /// how you ask by setting a param in the Ctor it Self public DepartmentRepository(MVCAppDemoDbcontext dbContext)
            /// to make it work in front End Don`t Forget to Add "services.AddDbContext<MVCAppDemoDbcontext>();" in your PL.StartUp.CS 
            
            _dbContext = dbContext;

        }
        public int Add(Department department)
        {
            _dbContext.Departments.Add(department);
            return _dbContext.SaveChanges();
        }

        public int Delete(Department department)
        {
            _dbContext.Departments.Remove(department);
            return _dbContext.SaveChanges();
        }

        public Department Get(int Id)
            //var department =  _dbContext.Departments.Local.Where(D=>D.Id == id).FirstOrDefault();
            //if (department == null)
            //    department = _dbContext.Departments.Where(D => D.Id == id).FirstOrDefault();
            => _dbContext.Departments.Find(Id);

        public IEnumerable<Department> GetAll()
            => _dbContext.Departments.ToList();

        public int Update(Department department)
        {
            _dbContext.Departments.Update(department);
            return _dbContext.SaveChanges();
        }
    }
}
