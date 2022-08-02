using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class InvoiceHelper
    {
        public static AuditMemo<Invoice> Finalize(Invoice inv)
        {
            inv.IsFinalized = true;
            var result = new AuditMemo<Invoice>(inv);

            return CreateAuditMemo(inv, "Finalized Invoice");
        }

        public static AuditMemo<Invoice> UnFinalize(Invoice inv)
        {
            inv.IsFinalized = false;
            var result = new AuditMemo<Invoice>(inv);

            return CreateAuditMemo(inv, "Unfinalized Invoice");
        }

        public static Func<Invoice, AuditMemo<Invoice>> AlterPrice(decimal amount)
        { 
            var transform = (Invoice inv) => {
                inv.Price = amount;

                return CreateAuditMemo(inv, "Changed Price");
            };
            return transform;
        }

        private static AuditMemo<Invoice> CreateAuditMemo(Invoice inv, string messageText)
        { 
            var result = new AuditMemo<Invoice>(inv);
            result.AuditEntries.Add($"{messageText}: {Newtonsoft.Json.JsonConvert.SerializeObject(inv)}");
            return result;
        }
    }
}
