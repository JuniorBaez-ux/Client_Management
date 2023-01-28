using Client_Management.DAL;
using Client_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto_FInal_Administracion_De_Sistemas.BLL
{
    public class ClientsTypesBLL
    {
        static CustomerTypes customerstypes = new CustomerTypes();
        public static bool Save(CustomerTypes customerstypes)
        {
            if (!Exists(customerstypes.Id))
            {
                return Insert(customerstypes);
            }
            else
            {
                return Modify(customerstypes);
            }
        }

        public static bool Insert(CustomerTypes customerstypes)
        {   
            bool pass = false;
            Context context = new Context();

            try
            {
                context.CustomerTypes.Add(customerstypes);
                pass = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return pass;
        }

        public static bool Modify(CustomerTypes customerstypes)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Entry(customerstypes).State = EntityState.Modified;
                pass = context.SaveChanges() > 0;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return pass;
        }

        public static bool Delete(int id)
        {
            bool pass = false;
            Context context = new Context();
            try
            {
                var CustomersTypes = context.CustomerTypes.Find(id);
                if (CustomersTypes != null)
                {
                    context.Entry(CustomersTypes).State = EntityState.Deleted;
                    pass = context.SaveChanges() > 0;

                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return pass;
        }

        public static bool Exists(int id)
        {
            Context context = new Context();
            bool found = false;
            try
            {
                found = context.CustomerTypes.Any(e => e.Id == id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return found;
        }

        public static CustomerTypes Search(int id)
        {
            Context context = new Context();
            CustomerTypes? customerTypes;
            try
            {
                customerTypes = context.CustomerTypes.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return customerTypes;
        }

        public static List<CustomerTypes> GetList(Expression<Func<CustomerTypes, bool>> criteria)
        {
            List<CustomerTypes> list = new List<CustomerTypes>();
            Context context = new Context();
            try
            {
                list = context.CustomerTypes.Where(criteria).ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return list;
        }
    }
}
