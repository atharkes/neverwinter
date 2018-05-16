using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseInterface.Structure.Constraints {
    class ForeignKey : Constraint {
        public Table ForeignTable { get; }

        public override string GetString() {
            throw new NotImplementedException();
        }
    }
}
