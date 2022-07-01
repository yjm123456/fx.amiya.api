using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreCountPartitionWhByIdAndStatusRequest : JdRequestBase<StoreCountPartitionWhByIdAndStatusResponse>
    {
                                                                                                                   public  		string
              status
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.store.countPartitionWhByIdAndStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("status", this.            status
);
                                                    }
    }
}





        
 

