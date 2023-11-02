using SmallWorld.src.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmallWorld.src.Model.MapModel
{
    public class Map
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MapId { get; set; }
        private List<Land> lands;


        internal List<Land> Lands { get => lands; set => lands = value; }

        public Map(List<Land> lands)
        {
            Lands = lands;
        }
        public Map()
        {
            Lands = new List<Land>();
        }
        public override string ToString()
        {
            return MapId.ToString();
        }
    }
}
