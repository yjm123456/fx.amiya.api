using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class WarehouseInboundOrderQueryListRequest : JdRequestBase<WarehouseInboundOrderQueryListResponse>
    {
                                                                                                                                                                               public  		Nullable<int>
              pageIndex
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              createTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              unpackingTimeBegin
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              unpackingTimeEnd
 {get; set;}
                                                          
                                                          public  		string
              remark1
 {get; set;}
                                                          
                                                          public  		string
              remark2
 {get; set;}
                                                          
                                                          public  		string
              remark3
 {get; set;}
                                                          
                                                          public  		string
              remark4
 {get; set;}
                                                          
                                                          public  		string
              remark5
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.warehouse.inbound.order.query.list";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("pageIndex", this.            pageIndex
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("createTimeBegin", this.            createTimeBegin
);
                                                                                                        parameters.Add("createTimeEnd", this.            createTimeEnd
);
                                                                                                        parameters.Add("unpackingTimeBegin", this.            unpackingTimeBegin
);
                                                                                                        parameters.Add("unpackingTimeEnd", this.            unpackingTimeEnd
);
                                                                                                        parameters.Add("remark1", this.            remark1
);
                                                                                                        parameters.Add("remark2", this.            remark2
);
                                                                                                        parameters.Add("remark3", this.            remark3
);
                                                                                                        parameters.Add("remark4", this.            remark4
);
                                                                                                        parameters.Add("remark5", this.            remark5
);
                                                                            }
    }
}





        
 

