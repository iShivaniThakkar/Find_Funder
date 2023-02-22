using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FindFunder.Infra.Domain.Entities
{
    public class InvestmentStatistics
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public decimal GivenEquity { get; set; }
        public decimal RemainEquity { get; set; }
        public long RaisedAmount { get; set; }
        public long RemainAmount { get; set;}
        
        [ForeignKey(nameof(ProposalId))]    
        public long ProposalId { get; set; }
        public virtual Proposal Proposal { get; set; }

        public InvestmentStatistics()
        {

        }
        public InvestmentStatistics(decimal givenEquity, decimal remainEquity, long raisedAmount, long remainAmount, long proposalId)
        {
           
            GivenEquity = givenEquity;
            RemainEquity = remainEquity;
            RaisedAmount = raisedAmount;
            RemainAmount = remainAmount;
            ProposalId = proposalId;
           
        }
    }
}
