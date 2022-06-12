using EnterpriseOrganizationMaintain.Models;
using Microsoft.AspNetCore.Mvc;


namespace EnterpriseOrganizationMaintain.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        [HttpPost("add-employee")]
        public void AddEmployee(Employee employees)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.Employees.Add(employees);
                db.SaveChanges();
            }

        }

        [HttpPost("add-hr-data")]
        public void AddHrData(HrData hrdata)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                db.HrData.Add(hrdata);
                db.SaveChanges();
            }

        }

        [HttpGet("get-hr-data")]
        public HrData GetHrData(int employeeId)
        {
            
            using (ApplicationContext db = new ApplicationContext())
            {
                var info = (from f in db.HrData
                         where f.EmployeeId == employeeId
                            where f.IsDeleted == false
                            select f).SingleOrDefault();

                if (info == null)
                    throw new Exception("Wrong EmployeeId");

                return info;
            }
            
        }

        [HttpGet("get-email-by-employee-id")]
        public string GetEmailByEmployeeId(int employeeId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var email = (from f in db.Employees
                             where f.Id == employeeId
                             where f.IsDeleted == false
                             select f.Email).SingleOrDefault();

                if (email == null )
                    throw new Exception("Wrong EmployeeId");

                return email;
            }
        }

        [HttpGet("update-hr-data")]
        public HrData UpdateHrData(HrData hrData)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                var info = (from f in db.HrData
                            where f.EmployeeId == hrData.EmployeeId
                            where f.IsDeleted == false
                            select f ).SingleOrDefault();

                if (info == null )
                    throw new Exception("Wrong HrData");

                info.SecurityNumber = hrData.SecurityNumber;
                info.Salary = hrData.Salary;
                db.SaveChanges();

                return info;
            }

        }

        [HttpGet("soft-delete")]
        public void SoftDelete(int employeeId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var infoEmployee = (from f in db.Employees
                            where f.Id == employeeId
                            select f).SingleOrDefault();

                var infoHrData = (from f in db.HrData
                                    where f.EmployeeId == employeeId
                                  select f).SingleOrDefault();

                if (infoEmployee == null || infoHrData == null)
                    throw new Exception("Wrong EmployeeId");

                infoEmployee.IsDeleted = true;
                infoHrData.IsDeleted = true;
                db.SaveChanges();

            }

        }

        [HttpGet("hard-delete")]
        public void HardDelete(int employeeId)
        {

            using (ApplicationContext db = new ApplicationContext())
            {
                var infoEmployee = (from f in db.Employees
                                    where f.Id == employeeId
                                    select f).SingleOrDefault();

                var infoHrData = (from f in db.HrData
                                  where f.EmployeeId == employeeId
                                  select f).SingleOrDefault();

                if (infoEmployee == null || infoHrData == null)
                    throw new Exception("Wrong EmployeeId");

                db.Employees.Remove(infoEmployee);
                db.HrData.Remove(infoHrData);
                db.SaveChanges();

            }

        }

        [HttpGet("reverce-deleted-employee")]
        public void ReverceDeletedEmployee(int employeeId)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var infoEmployee = (from f in db.Employees
                                    where f.Id == employeeId
                                    select f).SingleOrDefault();

                var infoHrData = (from f in db.HrData
                                  where f.EmployeeId == employeeId
                                  select f).SingleOrDefault();

                if (infoEmployee == null || infoHrData == null)
                    throw new Exception("Wrong EmployeeId");

                infoEmployee.IsDeleted = false;
                infoHrData.IsDeleted = false;
                db.SaveChanges();

            }

        }

        [HttpGet("employees")]
        public List<Employee> GetEmployeeList()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                List<Employee> employees = db.Employees.ToList();

                return employees;
            }
        }

        [HttpGet("hr-datas")]
        public List<HrData> GetHrDataList()
        {
            List<HrData> hrData;
            using (ApplicationContext db = new ApplicationContext())
            {
                hrData = db.HrData.ToList();
            }

            return hrData;
        }

    }
}
