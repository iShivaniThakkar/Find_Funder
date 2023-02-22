using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class Investment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }  
        public string InvestmentStatus { get; set; }
        public decimal EquityPercentage { get; set; }
        public long Amount { get; set; }
        public DateTime TransactionDate { get; set; }
        
        
        [ForeignKey(nameof(ProposalId))]
        public long ProposalId { get; set; }
        public virtual Proposal Proposal { get; set; }
        
        
        [ForeignKey(nameof(InvestorId))]
        public long InvestorId { get; set; }
        public virtual Investor Investor { get;set; }

        public Investment()
        {

        }
        public Investment(string investmentStatus,decimal equityPercentage,long amount,DateTime transactionDate,long proposalId,long investorId)
        {
            InvestmentStatus = investmentStatus;
            EquityPercentage = equityPercentage;
            Amount = amount;
            TransactionDate= transactionDate;
            ProposalId = proposalId;
            InvestorId = investorId;
        }
    }
}
