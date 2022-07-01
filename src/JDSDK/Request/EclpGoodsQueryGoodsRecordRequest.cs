using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpGoodsQueryGoodsRecordRequest : JdRequestBase<EclpGoodsQueryGoodsRecordResponse>
    {
                                                                                                                                                                               public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              isvGoodsNo
 {get; set;}
                                                          
                                                          public  		string
              goodsNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startDate
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endDate
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.eclp.goods.queryGoodsRecord";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("isvGoodsNo", this.            isvGoodsNo
);
                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                            }
    }
}





        
 

