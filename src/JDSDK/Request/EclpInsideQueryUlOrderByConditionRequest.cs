using System;
using System.Collections.Generic;
using Jd.Api.Response;
using Jd.Api.Util;
namespace Jd.Api.Request
{
    public class EclpInsideQueryUlOrderByConditionRequest : JdRequestBase<EclpInsideQueryUlOrderByConditionResponse>
    {
                                                                                  public  		string
              pageSize
 {get; set;}
                                                          
                                                          public  		string
              pageNum
 {get; set;}
                                                          
                                                                                                                      public  		string
              ulNo
 {get; set;}
                                                          
                                                          public  		string
              outUlNo
 {get; set;}
                                                          
                                                          public  		string
              deptNo
 {get; set;}
                                                          
                                                          public  		string
              warehouseNo
 {get; set;}
                                                          
                                                          public  		string
              allowReturnDest
 {get; set;}
                                                          
                                                                              public override string ApiName
            {
                get{return "jingdong.eclp.inside.queryUlOrderByCondition";}
            }
            protected override void PrepareParam(IDictionary<String, Object> parameters)
            {
                                                                                                parameters.Add("pageSize", this.            pageSize
);
                                                                                                        parameters.Add("pageNum", this.            pageNum
);
                                                                                                                                                parameters.Add("ulNo", this.            ulNo
);
                                                                                                        parameters.Add("outUlNo", this.            outUlNo
);
                                                                                                        parameters.Add("deptNo", this.            deptNo
);
                                                                                                        parameters.Add("warehouseNo", this.            warehouseNo
);
                                                                                                        parameters.Add("allowReturnDest", this.            allowReturnDest
);
                                                                                                                            }
    }
}





        
 

