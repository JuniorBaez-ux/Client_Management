using Client_Management.DAL;
using Client_Management.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Client_Management.BLL
{
    public class InvoicesBLL
    {
        static Invoice invoice = new Invoice();
        public static bool Save(Invoice invoices)
        {
            if (!Exists(invoices.Id))
            {
                return Insert(invoices);
            }
            else
            {
                return Modify(invoices);
            }
        }

        public static bool Insert(Invoice invoices)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Invoices.Add(invoices);
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

        public static bool Modify(Invoice invoice)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Entry(invoice).State = EntityState.Modified;
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
                var Invoices = context.Invoices.Find(id);
                if (Invoices != null)
                {
                    context.Entry(Invoices).State = EntityState.Deleted;
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
                found = context.Invoices.Any(e => e.Id == id);
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

        public static Invoice Search(int id)
        {
            Context context = new Context();
            Invoice? Invoice;
            try
            {
                Invoice = context.Invoices.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return Invoice;
        }

        public static List<Invoice> GetList(Expression<Func<Invoice, bool>> criteria)
        {
            List<Invoice> list = new List<Invoice>();
            Context context = new Context();
            try
            {
                list = context.Invoices.Where(criteria).ToList();
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
