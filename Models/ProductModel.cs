using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace MySqlDemo.Models
{
    [MetadataType(typeof(ProductMetaData))]
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int qty { get; set; }

    }

    public class ProductMetaData
    {
        [Required]
        [Display(Name = "Product Name")]
        public string Name { get; set; }
    }
}