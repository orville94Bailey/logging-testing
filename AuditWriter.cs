using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public static class AuditWriter 
    {
        public static AuditMemo<TAuditee> RunWithAudit<TAuditee>(AuditMemo<TAuditee> input, Func<TAuditee, AuditMemo<TAuditee>> transform)
        { 
            var result = transform(input.Auditee);
            input.AuditEntries.AddRange(result.AuditEntries);

            return new AuditMemo<TAuditee> {
                Auditee = result.Auditee,
                AuditEntries = input.AuditEntries
            };
        }

        public static AuditMemo<TAuditee> RunWithAudit<TAuditee>(TAuditee auditee, Func<TAuditee, AuditMemo<TAuditee>> transform)
        {
            return RunWithAudit(new AuditMemo<TAuditee>(auditee), transform);
        }
    }

    public class AuditMemo<TAuditee>
    {
        public AuditMemo()
        {
        }

        public AuditMemo(TAuditee auditee){
            Auditee = auditee;
        }

        public TAuditee? Auditee { get; init; }
        public List<string> AuditEntries { get; init; } = new List<string>();

        public AuditMemo<TAuditee> Run(Func<TAuditee, AuditMemo<TAuditee>> transform)
        {
            return AuditWriter.RunWithAudit(this, transform);
        }
    }
}
