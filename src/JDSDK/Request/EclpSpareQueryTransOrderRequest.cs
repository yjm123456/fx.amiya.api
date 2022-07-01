using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpSpareQueryTransOrderRequest : JdRequestBase<EclpSpareQueryTransOrderResponse>
    {
                                                                                                                                              public  		string
              deptName
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              orderType
 {get; set;}
                                                          
                                                          public  		string
              destWarehouseNo
 {get; set;}
                                                          
                                                          public  		string
              sellerName
 {get; set;}
                                                          
                                                          public  		string
              sellerNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		string
              startWarehouseNo
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              type
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNum
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.spare.queryTransOrder";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptName", this.            deptName
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("destWarehouseNo", this.            destWarehouseNo
);
                                                                                                        parameters.Add("sellerName", this.            sellerName
);
                                                                                                        parameters.Add("sellerNo", this.            sellerNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("startWarehouseNo", this.            startWarehouseNo
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("type", this.            type
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                            }
    }
}





        
 

