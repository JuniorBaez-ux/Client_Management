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
    public class ClientsBLL
    {
        static Customers customers = new Customers();
        public static bool Save(Customers customers)
        {
            if (!Exists(customers.Id))
            {
                return Insert(customers);
            }
            else
            {
                return Modify(customers);
            }
        }

        public static bool Insert(Customers customer)
        {   
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Customers.Add(customer);
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

        public static bool Modify(Customers customer)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Entry(customer).State = EntityState.Modified;
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
                var Clients = context.Customers.Find(id);
                if (Clients != null)
                {
                    context.Entry(Clients).State = EntityState.Deleted;
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
                found = context.Customers.Any(e => e.Id == id);
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

        public static bool NameExists(string customer)
        {
            Context context = new Context();
            bool found = false;
            try
            {
                found = context.Customers.Any(e => e.CustName.ToLower() == customer.ToLower());
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

        public static Customers Search(int id)
        {
            Context context = new Context();
            Customers customers;
            try
            {
                customers = context.Customers.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return customers;
        }

        public static List<Customers> GetList(Expression<Func<Customers, bool>> criteria)
        {
            List<Customers> list = new List<Customers>();
            Context context = new Context();
            try
            {
                list = context.Customers.Where(criteria).ToList();
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

        public static bool IsActive(string nombre)
        {
            Context context = new Context();
            bool found = false;
            try
            {
                found = context.Customers.Any(e => e.CustName.ToLower() == nombre.ToLower() && e.Status != false);
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
    }
}
