using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DeleteStoresByIdRequest : JdRequestBase<DeleteStoresByIdResponse>
    {
                                                                                                                   public  		Nullable<long>
              storeId
 {get; set;}
                                                          
            public override string ApiName
            {
                get{return "jingdong.deleteStoresById";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("storeId", this.            storeId
);
                                                    }
    }
}





        
 

