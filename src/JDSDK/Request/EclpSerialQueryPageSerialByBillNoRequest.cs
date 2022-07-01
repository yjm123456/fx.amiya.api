using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpSerialQueryPageSerialByBillNoRequest : JdRequestBase<EclpSerialQueryPageSerialByBillNoResponse>
    {
                                                                                                                                              public  		string
              billNo
 {get; set;}
                                                          
                                                          public  		string
              billType
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
                get{return "jingdong.eclp.serial.queryPageSerialByBillNo";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("billNo", this.            billNo
);
                                                                                                        parameters.Add("billType", this.            billType
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





        
 

