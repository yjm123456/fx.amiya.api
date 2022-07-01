using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreFindPartitionWhByIdAndStatusRequest : JdRequestBase<StoreFindPartitionWhByIdAndStatusResponse>
    {
                                                                                                                   public  		string
              status
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.store.findPartitionWhByIdAndStatus";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("status", this.            status
);
                                                    }
    }
}





        
 

