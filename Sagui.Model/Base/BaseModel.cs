using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sagui.Model.Base
{
    public class BaseModel
    {
        [Key, Column(Order = 1)]
        public int Id { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid PublicID { get; set; }
        public int Status { get; set; }

        public PagingParameterModel PagingParameter { get; set; }
    }
}
