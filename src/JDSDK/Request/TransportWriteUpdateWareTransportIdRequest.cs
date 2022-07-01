using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class TransportWriteUpdateWareTransportIdRequest : JdRequestBase<TransportWriteUpdateWareTransportIdResponse>
    {
                                                                                                                                                                                                                                                                                                                   public  		Nullable<long>
              wareId
 {get; set;}
                                                          
                                                          public  		Nullable<long>
              transportId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.transport.write.updateWareTransportId";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                                                                                                                                                parameters.Add("wareId", this.            wareId
);
                                                                                                        parameters.Add("transportId", this.            transportId
);
                                                    }
    }
}





        
 

