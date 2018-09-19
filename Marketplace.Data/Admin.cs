using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
     public class Admin
    {
        [Key]
        public int AdminId { get; set; }
        //TODO: add more props
    }
}
