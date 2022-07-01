using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseOutboundOrderQueryConditionRequest : JdRequestBase<WarehouseOutboundOrderQueryConditionResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              stockOutNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTimeEnd
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.warehouse.outbound.order.query.condition";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("stockOutNo", this.            stockOutNo
);
                                                                                                        parameters.Add("createTimeBegin", this.            createTimeBegin
);
                                                                                                        parameters.Add("createTimeEnd", this.            createTimeEnd
);
                                                                            }
    }
}





        
 

