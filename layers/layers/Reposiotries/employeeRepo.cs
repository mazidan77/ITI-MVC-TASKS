using layers.Models;

namespace layers.Reposiotries
{
    public class employeeRepo : IemployeeRepo
    {
        companyDBcontext DB;
        public employeeRepo(companyDBcontext DB)
        {
            this.DB = DB;
        }


        //get all
        public List<employee> getAll()
        {

            return DB.employees.ToList();
        }

        //get by id 

        public employee getById(int id)
        {

            return DB.employees.Where(x => x.SSN == id).SingleOrDefault();

        }

        //add
        public int Add(employee emp)
        {

            DB.employees.Add(emp);
            return DB.SaveChanges();
        }

        //update
        public int Edit(employee emp)
        {
            var oldEmp = DB.employees.Where(x => x.SSN == emp.SSN).SingleOrDefault();
            oldEmp.Fname = emp.Fname;
            oldEmp.Bdate = emp.Bdate;
            oldEmp.Lname = emp.Lname;
            oldEmp.salary = emp.salary;
            oldEmp.superid = emp.superid;
            oldEmp.workid = emp.workid;
            oldEmp.address = emp.address;
            oldEmp.Mname = emp.Mname;
            oldEmp.SSN = emp.SSN;

            return DB.SaveChanges();

        }

        public int Delete(int id)
        {

            var q = DB.employees.Where(x => x.SSN == id).SingleOrDefault();
            DB.employees.Remove(q);
            return DB.SaveChanges();

        }




    }
}
