using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpSerialQueryInStockSIDBySkuRequest : JdRequestBase<EclpSerialQueryInStockSIDBySkuResponse>
    {
                                                                                                                                              public  		string
              goodsNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              queryType
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.serial.queryInStockSIDBySku";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("goodsNo", this.            goodsNo
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("queryType", this.            queryType
);
                                                                                                                            }
    }
}





        
 

