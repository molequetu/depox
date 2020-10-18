using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using depox.Core.Entities;

namespace depox.Web.ApiModels
{
    public class BinDto
    {
        public  int Id { get; set; }

        [Required]
        public string Code { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }


        public static BinDto FromBin(Bin bin)
        {
            return new BinDto()
            {
                Id = bin.Id,
                Code = bin.Code,
                Name = bin.Name,
                Description = bin.Description
            };
        }

    }

    public class BinItemsDto
    {
        public int Id { get; set; }

        public string Code { get; set; }

        public List<Item> Items { get; set; }

        public static BinItemsDto FromBin(Bin bin)
        {
            return new BinItemsDto()
            {
                Id = bin.Id,
                Code = bin.Code,
                Items = bin.Items.ToList()
            };
        }
    }
}