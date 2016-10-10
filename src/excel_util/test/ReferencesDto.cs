using eh.attributes;
using eh.attributes.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    public class ReferencesDto
    {
        public int Id { get; set; }
        [Col("A")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.STRING)]
        public string Name { get; set; }

        [Col("B")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.STRING)]
        public string Tel { get; set; }

        [Col("C")]
        [ColDataConstraint(ConstraintsEnum.NOTNULL)]
        [ColDataValid(DataTypeEnum.INT)]
        public int SchoolId { get; set; }
    }
}
