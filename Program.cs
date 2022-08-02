// See https://aka.ms/new-console-template for more information
using ConsoleApp1;

Console.WriteLine("Hello, World!");

var invoice = new Invoice();

var auditableInvoice = AuditWriter.RunWithAudit(invoice,InvoiceHelper.AlterPrice(40))
    .Run(InvoiceHelper.Finalize);

auditableInvoice = AuditWriter.RunWithAudit(auditableInvoice,InvoiceHelper.UnFinalize)
    .Run(InvoiceHelper.AlterPrice(90))
    .Run(InvoiceHelper.Finalize);

auditableInvoice = AuditWriter.RunWithAudit(auditableInvoice,InvoiceHelper.UnFinalize)
    .Run(InvoiceHelper.AlterPrice(75))
    .Run(InvoiceHelper.Finalize);

;
