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
    public class InvoicesTypesBLL
    {
        static InvoiceDetail invoiceDetail = new InvoiceDetail();
        public static bool Save(InvoiceDetail invoicesdetails)
        {
            if (!Exists(invoicesdetails.Id))
            {
                return Insert(invoicesdetails);
            }
            else
            {
                return Modify(invoicesdetails);
            }
        }

        public static bool Insert(InvoiceDetail invoicesdetails)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.InvoiceDetails.Add(invoicesdetails);
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

        public static bool Modify(InvoiceDetail invoicesdetails)
        {
            bool pass = false;
            Context context = new Context();

            try
            {
                context.Entry(invoicesdetails).State = EntityState.Modified;
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
                var InvoicesDetails = context.InvoiceDetails.Find(id);
                if (InvoicesDetails != null)
                {
                    context.Entry(InvoicesDetails).State = EntityState.Deleted;
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
                found = context.InvoiceDetails.Any(e => e.Id == id);
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

        public static InvoiceDetail Search(int id)
        {
            Context context = new Context();
            InvoiceDetail? InvoiceDetail;
            try
            {
                InvoiceDetail = context.InvoiceDetails.Find(id);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                context.Dispose();
            }
            return InvoiceDetail;
        }

        public static List<InvoiceDetail> GetList(Expression<Func<InvoiceDetail, bool>> criteria)
        {
            List<InvoiceDetail> list = new List<InvoiceDetail>();
            Context context = new Context();
            try
            {
                list = context.InvoiceDetails.Where(criteria).ToList();
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
