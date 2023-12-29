using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ApiWithDbms.Model
{
    public class Students
    {
       
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address{ get; set; }

        public int RollNo { get; set; }


    }
}
