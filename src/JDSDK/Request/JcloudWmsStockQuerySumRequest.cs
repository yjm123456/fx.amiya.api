using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class JcloudWmsStockQuerySumRequest : JdRequestBase<JcloudWmsStockQuerySumResponse>
    {
                                                                                                                                                                                                                public  		string
              skuNo
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              tenantId
 {get; set;}
                                                          
                                             public override string ApiName
            {
                get{return "jingdong.jcloud.wms.stock.query.sum";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                                                                                                                        parameters.Add("skuNo", this.            skuNo
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("tenantId", this.            tenantId
);
                                                                            }
    }
}





        
 

