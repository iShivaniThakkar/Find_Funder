using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FindFunder.Infra.Domain.Entities
{
    public class User:Audit
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] Password { get; set; }
        public byte[] PasswordSalt { get; set; }

        public User() { }

        public User(string firstName, string lastName, string email, byte[] password, byte[] passwordSalt)
        {
        
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Password = password;
            PasswordSalt = passwordSalt;
            CreatedOn= DateTime.UtcNow;
            IsActive= true;
        }

        public User UpdateData(string firstName, string lastName, string email)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            UpdatedOn= DateTime.UtcNow;
            return this;
        }
    }
}
