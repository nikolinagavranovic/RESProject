using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelPodataka.DataModel
{
    [DataContract]
   public class RelationType
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }

        public RelationType(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public RelationType()
        {

        }
    }
}
