using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpSerialQueryPageSerialByOwnerNoAndConditionRequest : JdRequestBase<EclpSerialQueryPageSerialByOwnerNoAndConditionResponse>
    {
                                                                                                                                              public  		string
              billType
 {get; set;}
                                                          
                                                          public  		string
              ownerNo
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              startTime
 {get; set;}
                                                          
                                                          public  		Nullable<DateTime>
              endTime
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
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
                get{return "jingdong.eclp.serial.queryPageSerialByOwnerNoAndCondition";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("billType", this.            billType
);
                                                                                                        parameters.Add("ownerNo", this.            ownerNo
);
                                                                                                        parameters.Add("startTime", this.            startTime
);
                                                                                                        parameters.Add("endTime", this.            endTime
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
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





        
 

