using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsSearchsingleorderRequest : JdRequestBase<DropshipDpsSearchsingleorderResponse>
    {
                                                                                                                                                                               public  		Nullable<long>
              customOrderId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.searchsingleorder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("customOrderId", this.            customOrderId
);
                                                                            }
    }
}





        
 

