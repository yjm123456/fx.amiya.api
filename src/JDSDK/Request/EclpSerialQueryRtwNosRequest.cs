using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpSerialQueryRtwNosRequest : JdRequestBase<EclpSerialQueryRtwNosResponse>
    {
                                                                                  public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              status
 {get; set;}
                                                          
                                                                                                                      public  		string
              startDate
 {get; set;}
                                                          
                                                          public  		string
              endDate
 {get; set;}
                                                          
                                                          public  		string
              pageStart
 {get; set;}
                                                          
                                                          public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              source
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.serial.queryRtwNos";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("status", this.            status
);
                                                                                                                                                parameters.Add("startDate", this.            startDate
);
                                                                                                        parameters.Add("endDate", this.            endDate
);
                                                                                                        parameters.Add("pageStart", this.            pageStart
);
                                                                                                        parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("source", this.            source
);
                                                                                                                            }
    }
}





        
 

