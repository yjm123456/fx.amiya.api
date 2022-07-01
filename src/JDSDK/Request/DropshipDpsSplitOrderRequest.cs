using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsSplitOrderRequest : JdRequestBase<DropshipDpsSplitOrderResponse>
    {
                                                                                                                   public  		string
              splitOrderJson
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.dropship.dps.splitOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("splitOrderJson", this.            splitOrderJson
);
                                                    }
    }
}





        
 

