using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpExceptionQueryExceptionListRequest : JdRequestBase<EclpExceptionQueryExceptionListResponse>
    {
                                                                                                                                              public  		string
              deptNo
 {get; set;}
                                                          
                                                                                      public  		string
              orderNos
 {get; set;}
                                                          
                                                                                      public  		string
              isvOrderNos
 {get; set;}
                                                          
                                                          public  		string
              orderType
 {get; set;}
                                                          
                                                          public  		string
              bizType
 {get; set;}
                                                          
                                                          public  		string
              createTimeStart
 {get; set;}
                                                          
                                                          public  		string
              createTimeEnd
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageNo
 {get; set;}
                                                          
                                                          public  		Nullable<int>
              pageSize
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.exception.queryExceptionList";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("orderNos", this.            orderNos
);
                                                                                                        parameters.Add("isvOrderNos", this.            isvOrderNos
);
                                                                                                        parameters.Add("orderType", this.            orderType
);
                                                                                                        parameters.Add("bizType", this.            bizType
);
                                                                                                        parameters.Add("createTimeStart", this.            createTimeStart
);
                                                                                                        parameters.Add("createTimeEnd", this.            createTimeEnd
);
                                                                                                        parameters.Add("pageNo", this.            pageNo
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                                            }
    }
}





        
 

