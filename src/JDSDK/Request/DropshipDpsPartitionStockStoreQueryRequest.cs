using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class DropshipDpsPartitionStockStoreQueryRequest : JdRequestBase<DropshipDpsPartitionStockStoreQueryResponse>
    {
                                                                                                                                                                               public  		string
              status
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.dropship.dps.partitionStock.store.query";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("status", this.            status
);
                                                                            }
    }
}





        
 

