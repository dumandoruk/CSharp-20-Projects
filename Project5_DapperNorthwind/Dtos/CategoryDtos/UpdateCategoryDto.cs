using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project5_DapperNorthwind.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryID { get; set; }

        public int CategoryName { get; set; }
        public string Description { get; set; }
    }
}
