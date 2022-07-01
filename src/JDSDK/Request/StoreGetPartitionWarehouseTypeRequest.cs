using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class StoreGetPartitionWarehouseTypeRequest : JdRequestBase<StoreGetPartitionWarehouseTypeResponse>
    {
                                                                                                                   public  		string
                                                                                      seqNum
 {get; set;}
                                                                                                                                  
            public override string ApiName
            {
                get{return "jingdong.store.getPartitionWarehouseType";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                parameters.Add("seq_num", this.                                                                                    seqNum
);
                                                    }
    }
}





        
 

