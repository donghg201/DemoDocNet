using System.ComponentModel.DataAnnotations;

namespace Demo.Dto
{
    public class BranchDto
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Name { get; set; }

        public string State { get; set; }

        public string ZipCode { get; set; }
    }
}
