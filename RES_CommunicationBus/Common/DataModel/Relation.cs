using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ModelPodataka.DataModel
{
    [DataContract]
    public class Relation
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int FirstResourceId { get; set; }
        [DataMember]
        public int SecondResourceId { get; set; }
        [DataMember]
        public RelationType Type  { get; set; }


        public Relation() 
        { 

        }

        public Relation(int id, int firstResourceId, int secondResourceId, RelationType type)
        {
            Id = id;
            FirstResourceId = firstResourceId;
            SecondResourceId = secondResourceId;
            Type = type;
        }
    }
}
