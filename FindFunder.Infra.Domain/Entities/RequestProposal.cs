using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class RequestProposal
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        
        [ForeignKey(nameof(ProposalId))]
        public long ProposalId { get; set; }
        public virtual Proposal Proposal { get; set; }


        [ForeignKey(nameof(InvestorId))]
        public long InvestorId { get; set; }
        public virtual Investor Investor { get;set; }
        public RequestProposal()
        {

        }

        public RequestProposal(string status, DateTime date, long proposalId, long investorId)
        {
            Status=status;
            Date=date;  
            ProposalId=proposalId;
            InvestorId=investorId;
        }
    }
}
