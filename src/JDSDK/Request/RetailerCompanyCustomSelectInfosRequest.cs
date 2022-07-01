using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class RetailerCompanyCustomSelectInfosRequest : JdRequestBase<RetailerCompanyCustomSelectInfosResponse>
    {
                                                                                                                   public  		Nullable<int>
              sellerId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.retailer.company.custom.select.infos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("sellerId", this.            sellerId
);
                                                    }
    }
}





        
 

