using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace PatternDepenInjectUnityWcf.Contract
{
    [ServiceContract]
    public interface ICFDI
    {
        [OperationContract]
        string Stamp(string comprobante);
    }
}
