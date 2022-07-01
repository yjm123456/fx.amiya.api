using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpStockQueryGoodsLevelChangeRequest : JdRequestBase<EclpStockQueryGoodsLevelChangeResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              orderNo
 {get; set;}
                                                          
                                                          public  		string
              outLevel
 {get; set;}
                                                          
                                                          public  		string
              intoLevel
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              startTime
 {get; set;}
                                                          
                                                          public  		string
              endTime
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.stock.queryGoodsLevelChange";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNo", this.            orderNo
);
                                                                                                        parameters.Add("outLevel", this.            outLevel
);
                                                                                                        parameters.Add("intoLevel", this.            intoLevel
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                                            }
    }
}





        
 

